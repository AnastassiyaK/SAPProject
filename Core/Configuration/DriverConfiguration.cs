using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Configuration
{
    public class DriverConfiguration : IDriverConfiguration
    {
        [JsonProperty("hubUrl")]
        public string HubUrl { get; set; }

        [JsonProperty("TimeOutSearch")]
        public int TimeOutSearch { get; set; }

        [JsonProperty("Grid")]
        public bool UseGrid { get; set; }
    }
}
