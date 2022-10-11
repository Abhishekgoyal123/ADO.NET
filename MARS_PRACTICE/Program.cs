// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
Console.WriteLine("Hello, World!");


SqlConnection conn;
SqlCommand cmd;

conn = new SqlConnection("Data Source =.; Initial Catalog = eShoppingCodi; Integrated Security =SSPI ; MultipleActiveResultSets = True");

conn.Open();

cmd = new SqlCommand();

cmd.Connection = conn;

cmd.CommandType = System.Data.CommandType.Text;

string abc = "Select * from Category";
string abc2 = "Select * from Product";
SqlCommand C1 = new SqlCommand(abc, conn);
SqlCommand C2 = new SqlCommand(abc2, conn);

SqlDataReader R1= C1.ExecuteReader();

SqlDataReader R2 = C2.ExecuteReader();


//List<Category> records = new List<Category>();
while (R1.Read())
{
        Console.WriteLine(R1["CategoryName"]);

    while (R2.Read())
    {
        Console.WriteLine(R2["ProductName"]);

    }

}
