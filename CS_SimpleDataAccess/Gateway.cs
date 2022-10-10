using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_SimpleDataAccess;
using CS_SimpleDataAccess.Models;
using CS_SimpleDataAccess.DataAccess;


namespace CS_SimpleDataAccess
{
   public class Gateway
    {
        public virtual void GatewayMethod(IDbAccess<T, > dbAccess)
        {
            
        }

        public new void GatewayMethod(IDbAccess<Category, int> dbAccess1)
        {

        }
    }
}
