using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SimpleDataAccess.DataAccess
{
     public interface IDbAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        TEntity Delete(TPk id);
    }
}
