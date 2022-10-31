using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IDbAccessService<TEntity, in Tpk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Tpk id, TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
