using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.ResolverService.Models
{
    public class CommandItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("command")]
        public CommandType Command { get; set; }

        [JsonProperty("groupId")]
        public Guid GroupId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("params")]
        public Coordinate Params { get; set; }

        [JsonProperty("next_available")]
        public bool NextAvailable { get; set; }

        [JsonProperty("status_update_url")]
        public string CallbackUrl { get; set; }
    }
}
