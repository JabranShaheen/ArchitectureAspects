using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using EntityAbstractions.Entities;

namespace DataServiceAbstraction.DataService
{
    public interface IDataService <Entity>
        where Entity : AbstractEntity
    {
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetTopAsync(int top, bool asc);
        Task<Entity> GetAsync(Object EntityID);
        Task<string> InsertAsync(Entity Entity);
        Task<bool> UpdateAsync(Entity Entity);
        Task<bool> DeleteAsync(Entity Entity);
        Task<object> GetDataAsync(String SQLquery);
    }
}
