using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coditas.Ecomm.Repositories;

namespace Coditas.Ecomm.Repositories
{
    public interface IDbRepository<TEntity, in Tpk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(Tpk id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(Tpk id, TEntity entity);

        Task<TEntity> DeleteAsync(Tpk id);
    }
}
