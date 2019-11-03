using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pacer.ResolverService.Models;
using Pacer.ResolverService.Services;
using System;
using System.Collections.Generic;

namespace Pacer.ResolverService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueCommandController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public QueueCommandController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("")]
        public ApiResultModel QueueCommand(string commandId)
        {
            var configPath = $"{_hostingEnvironment.ContentRootPath}\\Commands\\{commandId}";

            if (!System.IO.File.Exists(configPath))
            {
                return new ApiResultModel
                {
                    Success = false,
                    Message = "Specified command not found"
                };
            }

            Console.WriteLine($"Loading configuration for {commandId}");

            var jsonCommand = System.IO.File.ReadAllText(configPath);

            var commands = JsonConvert.DeserializeObject<List<CommandItem>>(jsonCommand);

            Console.WriteLine($"{commands.Count} commands found. Queueing up now.");

            QueuedService.CommandItems = commands;

            Console.WriteLine($"Commands Queued! Waiting for Robot to read...");

            return new ApiResultModel
            {
                Success = true
            };
        }

        [Route("test")]
        public void LoadTestData()
        {
            QueueCommand("Autfhority1.json");
        }
    }
}
