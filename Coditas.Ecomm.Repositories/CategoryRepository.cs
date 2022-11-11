using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coditas.Ecomm.Repositories
{
    public class CategoryRepository : IDbRepository<Category, int>
    {
        eShoppingCodiContext context;

        public CategoryRepository(eShoppingCodiContext context)
        {
            this.context = context;
        }
       async Task<Category> IDbRepository<Category, int>.CreateAsync(Category entity)
        {
            try
            {
                var result = await context.Categories.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Category> IDbRepository<Category, int>.DeleteAsync(int id)
        {
            try
            {
                var record = await context.Categories.FindAsync(id);
                if (record == null)
                    throw new Exception($"The Record with Category Id {id} is Missing");
                context.Categories.Remove(record);
                await context.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //async Task<IEnumerable<Category>> IDbRepository<Category, int>.GetAsync()
        // {
        //     throw new NotImplementedException();
        // }

        async Task<Category> IDbRepository<Category, int>.GetAsync(int id)
        {
            var record = await context.Categories.FindAsync(id);
            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }

        async Task<IEnumerable<Category>> IDbRepository<Category, int>.GetAsync()
        {
            return await context.Categories.ToListAsync();
        }

        async Task<Category> IDbRepository<Category, int>.UpdateAsync(int id, Category entity)
        {
            try
            {
                var recordToUpate = await context.Categories.FindAsync(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");

                recordToUpate.CategoryName = entity.CategoryName;
                recordToUpate.BasePrice = entity.BasePrice;
                await context.SaveChangesAsync();
                return recordToUpate;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
