using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_1
{
    public interface IDbAccessService<TEntity, in Tpk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
