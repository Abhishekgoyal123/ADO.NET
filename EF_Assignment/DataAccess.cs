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
            var data = from customer in context.Customers
                       join order in context.Orders on customer.CustomerId equals order.CustomerId
                       group customer by customer.CustomerId into newTable
                       select new
                       {
                           id = newTable.Key,
                           value = newTable.Count()
                       };
            foreach (var v in data)
            {
                Console.WriteLine($"{v.id} {v.value}");
            }
        }

    }
}
