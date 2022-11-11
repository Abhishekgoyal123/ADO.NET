using Api_Assignment.Models;
using Api_Assignment;

namespace Api_Assignment
{
    public class ProductDataAccessService : IDbAccessService<Product, int>
    {
        eShoppingCodiContext context;

        public ProductDataAccessService(eShoppingCodiContext _context)
        {
            this.context = _context;

        }

        Task<Product> IDbAccessService<Product, int>.CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDbAccessService<Product, int>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IDbAccessService<Product, int>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<Product> IDbAccessService<Product, int>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Product> IDbAccessService<Product, int>.UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Search(string CategoryName)
        {
            var result = (from product in context.Products
                          join subcategory in context.SubCategories on product.SubCategoryId equals subcategory.SubCategoryId
                          join category in context.Categories on subcategory.CategoryId equals category.CategoryId
                          where category.CategoryName == CategoryName
                          select product).ToList();



            return result;

        }
    }
}
