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
    public class DBEngine
    {
        public static SqlConnection m_db { get; set; }
        public static string connectionString = @"Data Source=192.168.1.108\SQLEXPRESS;Initial Catalog=Reyuko_DB;User ID=admin;Password=admin";
        public DBEngine()
        {
            OpenDB();
        }
        public void CloseDB()
        {
            m_db.Close();
        }
        public SqlConnection GetDB()
        {
            return m_db;
        }
        private void OpenDB()
        {
            m_db = new SqlConnection(connectionString);
            m_db.Open();
        }
        public static void AddCurrencyRating(string curreny, string date, string strRate)
        {
            string sql = String.Format("select id_currency from dbo.currency where currency_name like '{0}'", curreny); // 
            int currency_id = -1;
            using (SqlCommand cmd = new SqlCommand(sql, m_db))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    try { currency_id = reader.GetInt32(0); }
                    catch(Exception e)
                    {
                        
                    }
                     
                    
                }
            }
            if (currency_id < 0)
                return;
            sql = "insert into [dbo].[exchange_rate] ([id_currency], [currency_code], [date], [exrate]) values (@currency_id, @curreny, @date, @strRate);";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, m_db);
                cmd.Parameters.AddWithValue("@currency_id", currency_id);
                cmd.Parameters.AddWithValue("@curreny", curreny);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@strRate", strRate);

                int result = cmd.ExecuteNonQuery();
                result = 0;
            }
            catch (Exception e)
            {
                int a = 1;
            }
        }
    }
}
