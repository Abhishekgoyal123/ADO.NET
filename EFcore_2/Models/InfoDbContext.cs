using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cod

namespace Code_First_2.Models
{
   public class InfoDbContext : DbContext
    {
        public InfoDbContext()
        {

        }

        public DbSet<Person> Persons{ get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = CodeCodeFirst; Integrated Security =SSPI; MultipleActiveResultSets =true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
            base.OnModelCreating(modelBuilder);
        }
    }
}
