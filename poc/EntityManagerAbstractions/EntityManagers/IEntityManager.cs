using EntityAbstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagerAbstractions.EntityManagers
{
    public interface IEntityManager<Entity> where Entity : AbstractEntity
    {
        Task<IList<Entity>> GetAllAsync();
        Task<Entity> GetAsync(Object EntityID);
        Task<string> InsertAsync(Entity Entity);
        Task<bool> UpdateAsync(Entity Entity);
        Task<bool> DeleteAsync(Entity Entity);
    }
}
