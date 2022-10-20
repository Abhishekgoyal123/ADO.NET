using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Assignment.Models;

namespace EF_Assignment
{
    
    public class DataAccess
    {
        NorthwindContext context;

        public DataAccess()
        {
            context = new NorthwindContext();
        }

        public void getData()
        {
            var result = from customer in context.Customers
                       join order in context.Orders on customer.CustomerId equals order.CustomerId
                       group customer by customer.CustomerId into newTable
                       select new
                       {
                           cusstomer_id = newTable.Key,
                           order_count = newTable.Count()
                       };
            foreach (var item in result)
            {
                Console.WriteLine($"{item.cusstomer_id} {item.order_count}");
            }
        }

        public void getData_2()
        {
            var data = from customer in context.Customers
                       join order in context.Orders on customer.CustomerId equals order.CustomerId
                       join Orderdetail in context.OrderDetails on order.OrderId equals Orderdetail.OrderId
                       orderby customer.ContactName ascending
                       //group customer by customer.ContactName into newTable
                       select new
                       {
                           orderid = Orderdetail.OrderId,
                           customerName = customer.ContactName,
                       };
            foreach (var item in data)
            {
                Console.WriteLine($"{item.customerName}  {item.orderid}");
            }
        }

        public void getData_3()
        {
            var data = from customer in context.Customers
                       join order in context.Orders on customer.CustomerId equals order.CustomerId
                       join Orderdetail in context.OrderDetails on order.OrderId equals Orderdetail.OrderId
                       orderby customer.ContactName ascending
                      
                       select  new
                       {
                           orderid = Orderdetail.OrderId,
                           customerName = customer.ContactName,
                           price = Orderdetail.UnitPrice * Orderdetail.Quantity
                       };
            foreach (var item in data)
            {
                Console.WriteLine($"{item.customerName}  {item.orderid} {item.price}");
            }
        }

        public void getData_5()
        {
            DateTime Start_date = new DateTime(1996, 07, 04);
            DateTime end_date = new DateTime(2030, 07, 04);

            var data = from customer in context.Customers
                       join order in context.Orders on customer.CustomerId equals order.CustomerId
                       join Orderdetail in context.OrderDetails on order.OrderId equals Orderdetail.OrderId
                       where order.OrderDate >=Start_date && order.OrderDate <= end_date
                       orderby customer.ContactName ascending
                       

                       select new
                       {
                           orderid = Orderdetail.OrderId,
                           customerName = customer.ContactName,
                           //price = Orderdetail.UnitPrice * Orderdetail.Quantity
                       };
            foreach (var item in data)
            {
                Console.WriteLine($"{item.customerName}  {item.orderid} ");
            }

        }



    }
}
