namespace Api_Northwind.Models
{
    public class ResponseObject
    {
        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public Order? Order { get; set; }

        public Customer? Customer { get; set; }

        public Employee? Employee { get; set; }

        public Shipper? Shipper { get; set; }

        public List<CustomersEmployeesShipper>? CustomersEmployeesShipper { get; set; }   
    }
}
