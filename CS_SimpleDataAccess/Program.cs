// See https://aka.ms/new-console-template for more information
using CS_SimpleDataAccess.Models;
using CS_SimpleDataAccess.DataAccess;
using System.Data.SqlClient;
using CS_SimpleDataAccess;

Console.WriteLine("hello world");

//CategoryDbAccess();


try
{
    //CategoryDbAccess categoryDbAccess = new CategoryDbAccess();

    //var categories = categoryDbAccess.GetRecords();
    Report report = new Report();
    var res=report.GetProduct();
    for(int i=0;i<res.Count;i+=2)
    {
        Console.Write(res[i]+"  ");
        Console.WriteLine(res[i + 1]);

    }   
    //PrintData(categories);


}

catch (Exception ex)
{
    Console.WriteLine($"Error Occurred {ex.Message}");
}
Console.ReadLine();



static void PrintData(IEnumerable<Category> categories)
{
    foreach (var cat in categories)
    {
        Console.WriteLine($"{cat.CategoryId} {cat.CategoryName} {cat.BasePrice}");
    }
}


    //static void CategoryDbAccess()
    //{
    //SqlConnection conn;
    //    conn = new SqlConnection("Data Source =.; Initial Catalog = eShoppingCodi; Integrated Security =SSPI");
    //}

 