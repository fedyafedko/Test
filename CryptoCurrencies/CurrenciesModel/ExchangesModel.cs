using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseModelExchanges<T> where T : class
    {
        public T Data { get; set; }
    }

    public class Exchange
    {
        public string ExchangeId { get; set; }
        public string? Name { get; set; }
        public int? Rank { get; set; }
        public decimal? PercentTotalVolume { get; set; }
        public decimal? VolumeUsd { get; set; }
        public string? ExchangeUrl { get; set; }

    }
}
