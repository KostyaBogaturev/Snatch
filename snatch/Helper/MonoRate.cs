using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace snatch.Helper
{

    public class MonoRate
    {
        public int curentCodeA { get; set; }
        public int curentCodeB { get; set; }
        public long date { get; set; }
        public double rateBuy { get; set; }
        public double rateSell { get; set; }
    }
}
