using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.ResolverService.Models
{
    public class ApiResultModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class ApiResultModel<T> : ApiResultModel
    {
        public T Result { get; set; }
    }
}
