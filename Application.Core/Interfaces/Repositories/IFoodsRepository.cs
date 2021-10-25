using NUCAL.Application.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Repositories
{
    public interface IFoodsRepository: IRepository<Food>
    {
        Task<Food> GetByName(string name);
        Task<Food> GetByIdWithDetails(string id);
        Task<List<Food>> GetAllWithCategories();
    }
}
