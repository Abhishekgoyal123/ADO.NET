using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CS_Dapper.Constants;
using System.Data;

namespace CS_Dapper.DbConnect
{
    internal class EShopingCodiContext
    {
        private readonly string connStr;

        public EShopingCodiContext()
        {
            connStr = StaticConstants.ConnectionString;
        }

        public IDbConnection CreateConnection () => new SqlConnection(connStr);

        
    }


}
