using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_SimpleDataAccess.Models;
using System.Data.SqlClient;

namespace CS_SimpleDataAccess.DataAccess
{
    
    internal class CategoryDbAccess
    {
        public static SqlConnection conn;
        SqlCommand cmd;

        public CategoryDbAccess()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog = eShoppingCodi; Integrated Security =SSPI");
        }

        public IEnumerable<Category> GetRecords()
        {
            List<Category> records = new List<Category>();



            try
            {
                conn.Open();

                cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Select * from Category";

                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {
                    records.Add(new Category()
                    {
                        CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                        CategoryName = Reader["CategoryName"].ToString(),
                        BasePrice = Convert.ToDecimal(Reader["BasePrice"])

                    });
                }
                //Reader.Close();

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return records;
        }
    }
}

