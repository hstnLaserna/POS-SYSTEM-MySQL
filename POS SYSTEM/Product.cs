using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_SYSTEM
{
    public class Product
    {
        public string Type { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string SugarLevel { get; set; }
        public string Addons { get; set; }
        public int Quantity { get; set; }
        public double SizePrice { get; set; }
        public double SinkerPrice { get; set; }
        public double ProductPrice { get; set; }
        public string Notes { get; set; }
        public double ComputePrice()
        {
            ProductPrice = ((SizePrice + SinkerPrice) * Quantity);
            return ProductPrice;
        }
    }
}
