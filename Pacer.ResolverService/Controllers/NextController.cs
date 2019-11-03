using Microsoft.AspNetCore.Mvc;
using Pacer.ResolverService.Models;
using Pacer.ResolverService.Services;
using System;
using System.Linq;

namespace Pacer.ResolverService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NextController : Controller
    {
        [Route("")]
        public ApiResultModel<CommandItem> GetNext()
        {
            Console.WriteLine($"Fetching next command...");

            var commandItem = QueuedService.CommandItems.FirstOrDefault();

            if (commandItem == null)
            {
                Console.WriteLine($"No commands available, returning to standby...");

                return new ApiResultModel<CommandItem>
                {
                    Success = true,
                    Message = "No items at this time.",
                    Result = null
                };
            }

            Console.WriteLine($"Commands found! please standby for robot movement.");

            return new ApiResultModel<CommandItem>
            {
                Success = true,
                Result = commandItem
            };
        }

        [Route("updatecommandstatus/{id}/{status}")]
        public ApiResultModel UpdateCommandStatus(int id, bool status)
        {
            var commandItem = QueuedService.CommandItems.FirstOrDefault(p => p.Id == id);

            if (commandItem == null)
            {
                return new ApiResultModel
                {
                    Success = false,
                    Message = "Item not found."
                };
            }

            if (status)
            {
                QueuedService.CommandItems.Remove(commandItem);
            }

            Console.WriteLine($"Command status updated. Returning to standby...");

            return new ApiResultModel
            {
                Success = true
            };
        }
    }
}