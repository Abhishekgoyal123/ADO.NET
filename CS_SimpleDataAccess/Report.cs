using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CS_SimpleDataAccess.Models;
using CS_SimpleDataAccess.DataAccess;

namespace CS_SimpleDataAccess
{
    internal class Report
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Report()
        {
            conn = new SqlConnection("Data Source =.; Initial Catalog = eShoppingCodi; Integrated Security =SSPI");
        }

        public List<string> GetProduct()
        {
            List<string> product_list = new List<string>();
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Product.ProductName, Category.CategoryName from Product, Category, SubCategory where Product.Sub_CategoryId = SubCategory.SubCategoryId and SubCategory.CategoryId = Category.CategoryId group by Product.ProductName, Category.CategoryName";

            SqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {

                product_list.Add(Reader["ProductName"].ToString());
                product_list.Add(Reader["CategoryName"].ToString());

                
                //product_list.Add(new Product()
                //{
                    
                //    ProductName = Reader["ProductName"].ToString(),
                    
                    

                //}) ;
            }
            Reader.Close();
            return product_list;
        }

        public List<string> Search()
        {

        }
    }
}
