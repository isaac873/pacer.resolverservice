using Pacer.ResolverService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.ResolverService.Services
{
    public static class QueuedService
    {
        public static List<CommandItem> CommandItems { get; set; } = new List<CommandItem>();
    }
}
