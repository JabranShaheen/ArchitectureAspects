using System.Collections.Generic;
using EntityAbstractions.Entities;
using System.Threading.Tasks;
using System;
using DataServiceAbstraction.DataService;

namespace DataService.Entities
{
    public class EntityDataService<Entity> : IDataService<Entity> where Entity : AbstractEntity
    {
        public Task<bool> DeleteAsync(Entity Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entity> GetAsync(object EntityID)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetDataAsync(string SQLquery)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entity>> GetTopAsync(int top, bool asc)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertAsync(Entity Entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Entity Entity)
        {
            throw new NotImplementedException();
        }
    }
}
