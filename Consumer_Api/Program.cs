// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


Console.WriteLine("Hello, World!");
Console.WriteLine("enter product name to search");
string productName = Console.ReadLine();
Console.WriteLine("Press a Key when Service Starts");
Console.ReadLine();

HttpClient client = new HttpClient();

var cats = await client.GetFromJsonAsync<List<Customer>>($"https://localhost:7088/api/Northwind_?productName={productName}");

foreach(var item in cats)
{
    Console.WriteLine($"{item.CustomerId} {item.CompanyName}");
}



Console.ReadLine();

public partial class Customer
{
    public Customer()
    {
        Orders = new HashSet<Order>();
    }
    public string CustomerId { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
public partial class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }
    public int OrderId { get; set; }
    public string? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }
    public string? OrderStatus { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
public partial class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
    public virtual Order Order { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
public partial class Product
{
    public Product()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    public string? QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}


