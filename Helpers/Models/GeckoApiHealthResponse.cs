﻿using Newtonsoft.Json;

namespace Helpers.Models
{
    public class GeckoApiHealthResponse
    {
        [JsonProperty("gecko_says")]
        public string GeckoSays { get; set; }
    }
}
