using System;
using System.Collections.Generic;

namespace API_1.Models
{
    public partial class Product
    {
        public int ProductUniqueId { get; set; }
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Descrition { get; set; } = null!;
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
