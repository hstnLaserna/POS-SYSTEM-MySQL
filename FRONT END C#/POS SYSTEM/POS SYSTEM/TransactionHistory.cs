using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SYSTEM
{
    public static class TransactionHistory
    {
        public static List<string> History = new List<string>();
        public static string[] orders = { };
        public static List<double> priceTotal = new List<double>();
    }
}
