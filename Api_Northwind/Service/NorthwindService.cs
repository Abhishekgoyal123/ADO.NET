using Api_Northwind.Service;
using Api_Northwind.Models;

namespace Api_Northwind.Service
{
    public class NorthwindService : IService<Customer>
    {
        NorthwindContext context;

        public NorthwindService(NorthwindContext context)
        {
            this.context = context; 
        }

       List<Customer> IService<Customer>.Search1(string productName)
        {
            var abc = (from Product in context.Products
                       join orderDetail in context.OrderDetails on Product.ProductId equals orderDetail.ProductId
                       join order in context.Orders on orderDetail.OrderId equals order.OrderId
                       join customer in context.Customers on order.CustomerId equals customer.CustomerId
                       where Product.ProductName == productName
                       select customer).ToList();
            return abc;
        }
    }

    
}
