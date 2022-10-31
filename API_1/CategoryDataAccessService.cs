using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_1.Models;

namespace API_1
{

    public class CategoryDataAccessService : IDbAccessService<Category, int> 
    {
        public Task<Category> CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(TPK id, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
