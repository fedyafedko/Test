using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CurrencyModel
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Supply { get; set; }
        public double PriceUSD { get; set; }
        public double ChangePercent { get; set; }
    }
}
