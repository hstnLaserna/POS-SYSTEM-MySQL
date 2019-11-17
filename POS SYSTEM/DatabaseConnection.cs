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
        public static string schema = "dbPOS";
        public static string dbuser = "happyt";
        public static string dbpassword = "bois";

        public static string connectionString = @"server=localhost;database=" + schema + ";uid=" + dbuser + ";pwd=" + dbpassword + "";
        public static string UsersTable = "tblUsers";
        public static string ProductsTable = "tblProducts";
        public static string AddonsTable = "tblAddons";
        public static string SalesTable = "tblsales";
    }
}
