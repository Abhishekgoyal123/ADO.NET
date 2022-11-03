using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Assignment.Models;
using Api_Assignment;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Api_Assignment
{

    public class CategoryDataAccessService : IDbAccessService<Category, int>
    {
        eShoppingCodiContext context;
        /// <summary>
        /// Injection. The eShoppingCodiContext instance will be 
        /// read from DI Container of the Application
        /// </summary>
        /// <param name="context"></param>
        public CategoryDataAccessService(eShoppingCodiContext context)
        {
            this.context = context;
        }

        async Task<Category> IDbAccessService<Category, int>.CreateAsync(Category entity)
        {
            try
            {
                var result = await context.Categories.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<bool> IDbAccessService<Category, int>.DeleteAsync(int id)
        {
            var recordToDelete = await context.Categories.FindAsync(id);
            if (recordToDelete == null) throw new Exception("Record for Delete is not found");

            context.Categories.Remove(recordToDelete);
            int result = await context.SaveChangesAsync();
            if (result > 0) return true;
            else
            {
                return false;
            }
        }

        async Task<IEnumerable<Category>> IDbAccessService<Category, int>.GetAsync()
        {
            return await context.Categories.ToListAsync();
        }

        async Task<Category> IDbAccessService<Category, int>.GetAsync(int id)
        {
            var record = await context.Categories.FindAsync(id);
            if (record == null)
                throw new Exception("Record  not found");
            return record;

        }

        async Task<Category> IDbAccessService<Category, int>.UpdateAsync(int id, Category entity)
        {
            try
            {
                var recordToUpate = await context.Categories.FindAsync(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");

                recordToUpate.CategoryName = entity.CategoryName;
                recordToUpate.BasePrice = entity.BasePrice;
                await context.SaveChangesAsync();
                return recordToUpate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Product> abcd(string CategoryName, string ProductName)
        {
            //eShoppingCodiContext context = new eShoppingCodiContext();

            // eShoppingCodiContext context = new eShoppingCodiContext();
            //Category c1 = new Category();
            //c1.CategoryName = CategoryName;
            //Product P1 = new Product();
            //P1.ProductName = ProductName;

            //var record = await context.Categories.FindAsync(CategoryName);
            //var record_1 = await context.Products.FindAsync(ProductName);


            var abc = (from prod in context.Products
                       join subcat in context.SubCategories on prod.SubCategoryId equals subcat.SubCategoryId
                       join cat in context.Categories on subcat.CategoryId equals cat.CategoryId
                       where cat.CategoryName == CategoryName && prod.ProductName == ProductName
                       select prod).ToList();
            //{
            //    category = cat.CategoryName,
            //    product = prod.ProductName,
            //    product_id = prod.ProductId
            //};
            return abc;
            //return Ok(abc);
        }
    }
}
