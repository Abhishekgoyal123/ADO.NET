using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_Assignment.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        [Required(ErrorMessage ="Category id is required")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public decimal BasePrice { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
