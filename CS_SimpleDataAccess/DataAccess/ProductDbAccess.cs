using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_SimpleDataAccess.Models;
using CS_SimpleDataAccess.DataAccess;
using System.Data.SqlClient;
using CS_SimpleDataAccess;

namespace CS_SimpleDataAccess.DataAccess
{
    public class ProductDbAccess : IDbAccess<Product, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public ProductDbAccess()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
        }
        Product IDbAccess<Product, int>.Create(Product entity)
        {
            throw new NotImplementedException();
        }

        Product IDbAccess<Product, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Product IDbAccess<Product, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IDbAccess<Product, int>.GetAll()
        {
            List<Product> Product_list = new List<Product>();

            Conn.Open();
            // 2. Creating ommand
            Cmd = new SqlCommand();
            // Set the COnnection object to COmmand
            Cmd.Connection = Conn;
            // 2.a. Setting the Command Properties for TExt 
            Cmd.CommandType = System.Data.CommandType.Text;
            Cmd.CommandText = "Select * from Product";

            SqlDataReader Reader = Cmd.ExecuteReader();
            // 3.a. STart REading Records
            while (Reader.Read())
            {
                Product_list.Add(new Product()
                {
                    ProductId = Reader["ProductId"].ToString(),
                    ProductName = Reader["ProductName"].ToString()
                    
                });
            }
            Reader.Close();
            return Product_list;
        }

        Product IDbAccess<Product, int>.Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}



