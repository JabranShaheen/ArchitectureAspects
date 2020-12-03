using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataServiceAbstraction.DataService;
using EntityAbstractions.Entities;
using EntityManagerAbstractions.EntityManagers;

namespace EntityManager
{
    public class GenericEntityManager<Entity> : IEntityManager<Entity> where Entity : AbstractEntity
    {
        
        IDataService<Entity> _DataService;

        public GenericEntityManager(IDataService<Entity> DataService)
        {
            _DataService = DataService;
        }

        public async Task<bool> DeleteAsync(Entity Entity)
        {
            await _DataService.DeleteAsync(Entity);
            return true;
        }

        public async Task<IList<Entity>> GetAllAsync()
        {
            return await _DataService.GetAllAsync();
        }

        public async Task<Entity> GetAsync(object EntityID)
        {
            return await _DataService.GetAsync(EntityID);
        }

        public virtual async Task<string> InsertAsync(Entity Entity)
        {
            return await _DataService.InsertAsync(Entity);            
        }

        public virtual async Task<bool> UpdateAsync(Entity Entity)
        {
            await _DataService.UpdateAsync(Entity);
            return true;
        }

    }
}