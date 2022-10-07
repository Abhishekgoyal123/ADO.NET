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
            Console.WriteLine("enter category name to search");
            string abc = Console.ReadLine();
            //var catergory = new Category();
            //catergory.CategoryName = Console.ReadLine();

             
            List<string> product_list = new List<string>();
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Product.ProductName, Category.CategoryName from Product, Category, SubCategory where Product.Sub_CategoryId = SubCategory.SubCategoryId and SubCategory.CategoryId = Category.CategoryId and Category.CategoryName = @abc group by Product.ProductName, Category.CategoryName";

            cmd.Parameters.AddWithValue("@abc",abc);
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

        public List<string> SearchProduct()
        {
            Console.WriteLine("enter name to search");
            string abc = Console.ReadLine();
            //var catergory = new Category();
            //catergory.CategoryName = Console.ReadLine();


            List<string> product_list = new List<string>();
            conn.Open();

            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Product.ProductName, Category.CategoryName , Manufacturer.Manufacturer_Name from Product, Category, SubCategory, Manufacturer where Product.Sub_CategoryId = SubCategory.SubCategoryId and SubCategory.CategoryId = Category.CategoryId and  Product.Manufacturer_Id = Manufacturer.Manufacturer_Id and (Manufacturer.Manufacturer_Name=@abc or Category.CategoryName=@abc) group by Product.ProductName, Category.CategoryName ,Manufacturer.Manufacturer_Name";

            cmd.Parameters.AddWithValue("@abc", abc);
            SqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {

                product_list.Add(Reader["ProductName"].ToString());
                product_list.Add(Reader["CategoryName"].ToString());
                product_list.Add(Reader["Manufacturer_Name"].ToString());


                //product_list.Add(new Product()
                //{

                //    ProductName = Reader["ProductName"].ToString(),



                //}) ;
            }
            Reader.Close();
            return product_list;

        }
    }
}
