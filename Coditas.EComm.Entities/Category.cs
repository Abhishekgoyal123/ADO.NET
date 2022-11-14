using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Coditas.EComm.Entities;

namespace Coditas.EComm.Entities
{
    public partial class Category
    {
        public Category()
        {
            //SubCategories = new HashSet<SubCategory>();
        }

        [Required(ErrorMessage = "Category id is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; } = null!;

        [Required(ErrorMessage = "Category base price is required")]
        public decimal BasePrice { get; set; }

        //public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
