using WebApplication1.Models;

namespace WebApplication1
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

        Task<bool> IDbAccessService<Product, int>.DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IDbAccessService<Product, int>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<Product> IDbAccessService<Product, int>.UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
