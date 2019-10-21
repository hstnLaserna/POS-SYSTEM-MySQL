using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_SYSTEM
{
    class MilkTea
    {
        public string MilkteaName { get; set; }
        public string Size { get; set; }
        public string SugarLevel { get; set; }
        public string Sinkers  { get; set; }
        public double Quantity { get; set; }
        public double SizePrice { get; set; }
        public double SinkerPrice { get; set; }
        public double  MilkteaPrice { get; set; }
        public double ComputePrice()
        {
            MilkteaPrice =  ((SizePrice + SinkerPrice) * Quantity );
            return MilkteaPrice;
        }
    }
}
