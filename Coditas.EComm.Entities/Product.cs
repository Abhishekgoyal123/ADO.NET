using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coditas.EComm.Entities
{
    public partial class Product
    {
        [Required(ErrorMessage = "Product unique id is required")]
        public int ProductUniqueId { get; set; }

        [Required(ErrorMessage = "Category id is required")]
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Descrition { get; set; } = null!;
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public int ManufacturerId { get; set; }

        //public virtual Manufacturer Manufacturer { get; set; } = null!;
        //public virtual SubCategory SubCategory { get; set; } = null!;
    }
}
