using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.ResolverService.Models
{
    public enum CommandType
    {
        Setup = 0,
        Reset = 1,
        Move = 2,
        Touch = 3
    }
}
