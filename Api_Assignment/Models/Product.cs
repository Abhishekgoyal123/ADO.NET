using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api_Assignment.CustomOps.CustomValidators;

namespace Api_Assignment.Models
{
    public partial class Product
    {
        public int ProductUniqueId { get; set; }
        public string ProductId { get; set; } = null!;

        [ProductNameNoSpecialChar(ErrorMessage ="Product name cannot contain special characters ")]
        public string ProductName { get; set; } = null!;
        public string Descrition { get; set; } = null!;
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual SubCategory SubCategory { get; set; } = null!;
    }
}
