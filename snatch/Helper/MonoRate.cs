using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace snatch.Helper
{

    public class MonoRate
    {
        [JsonProperty("curentCodeA")]
        public int CodeOtherCurrency { get; set; }
        [JsonProperty("curentCodeB")]
        public int CodeUAH { get; set; }
        [JsonProperty("curentCodeA")]
        public long Date { get; set; }
        [JsonProperty("rateBuy")]
        public double RateBuy { get; set; }
        [JsonProperty("rateSell")]
        public double RateSell { get; set; }
    }
}
