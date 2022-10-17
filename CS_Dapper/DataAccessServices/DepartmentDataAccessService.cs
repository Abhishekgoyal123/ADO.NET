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

        public async Task<List<Department>> GetAsync()
        {
            try
            {
                var query = StaticConstants.SelectQuery;
                // Generic Method that will accept a Model (e.g.Department)
                // and the Query eill be executed against the Deparment Table
                // (StaticConstants.SelectQuery) and the result ill be mapped with the Model
                var result = await _context.CreateConnection()
                        .QueryAsync<Department>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
