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
        Task<Category> IDbAccessService<Category, int>.CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDbAccessService<Category, int>.DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
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
