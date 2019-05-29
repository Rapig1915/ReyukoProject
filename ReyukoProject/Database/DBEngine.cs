using ReyukoProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Database
{
    class DBEngine
    {
        public static SqlConnection MyDB { get; set; }
        public static string connectionString = @"Data Source=192.168.1.108\SQLEXPRESS;Initial Catalog=Reyuko_DB;User ID=admin;Password=admin";
        public DBEngine()
        {

        }
        public static void AddCurrencyRating(string curreny, string date, string strRate)
        {

        }
    }
}
