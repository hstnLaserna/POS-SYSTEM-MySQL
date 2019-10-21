using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace POS_SYSTEM
{
    public class DatabaseConnection
    {
        public static string connectionString = @"server=localhost;database=dbPOS;uid=root;pwd=root";
        public static string UsersTable = "tblUsers";
        public static string ProductsTable = "tblProducts";
        public static string AddonsTable = "tblAddons";
        public static string SalesTable = "tblsales";
    }
}
