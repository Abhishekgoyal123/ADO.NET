using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CS_Dapper.Constants;
using CS_Dapper.DbConnect;
using CS_Dapper.Model;

namespace CS_Dapper.DataAccessServices
{
    internal class DepartmentDataAccessService
    {
        EShopingCodiContext? _context;
        
        public DepartmentDataAccessService()
        {
            _context = new EShopingCodiContext();
        }
    }
}
