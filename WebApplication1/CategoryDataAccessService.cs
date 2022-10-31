using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1;

namespace WebApplication1
{

    public class CategoryDataAccessService : IDbAccessService<Category, int>
    {
        eShoppingCodiContext context;

        public CategoryDataAccessService(eShoppingCodiContext _context)
        {
            this.context = _context;
        }
        async Task<Category> IDbAccessService<Category, int>.CreateAsync(Category entity)
        {
            try
            {
                var result = await context.Categories.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        Task<bool> IDbAccessService<Category, int>.DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

       
        async Task<Category> IDbAccessService<Category, int>.GetAsync(int id)
        {
            var record = await context.Categories.FindAsync(id);
            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }

        Task<IEnumerable<Category>> IDbAccessService<Category, int>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<Category> IDbAccessService<Category, int>.UpdateAsync(int id, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
