using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_SYSTEM
{
    class Transact
    {
        public static double Total { get; set; }
        public static double Discount { get; set; }
        public static string DiscountType { get; set; }
        public static double Cash { get; set; }
        public static double Change { get; set; }
        public static double VATable { get; set; }
        public static double VatAmt { get; set; }

        public static void isVATable(double price)
        {
            VATable = Math.Ceiling((Total / 1.12) * 100) / 100;
            VatAmt = Math.Ceiling((VATable * 0.12) * 100) / 100;
        }
        /*
        public static void transactionValues(double price)
        {
            if (DiscountType != null)
            {
                if (DiscountType.ToLower() == "senior citizen" || DiscountType.ToLower() == "pwd")
                {
                    Total = (Math.Ceiling((price / 1.12) * 100) / 100) * (1 - Discount);
                    VATable = 0;
                    VatAmt = 0;
                }
            }
            else if (Discount > 0)
            {
                Total = (price * (1 - Discount));
                VATable = Math.Ceiling((Total / 1.12) * 100) / 100;
                VatAmt = Math.Ceiling((VATable * 0.12) * 100) / 100;
            }
            else
            {
                Total = price + 5;
                VATable = Math.Ceiling((price / 1.12) * 100) / 100;
                VatAmt = Math.Ceiling((VATable * 0.12) * 100) / 100;
            }
        }
         */
    }
}
