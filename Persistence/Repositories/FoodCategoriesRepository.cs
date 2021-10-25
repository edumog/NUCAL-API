using Microsoft.EntityFrameworkCore;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace NUCAL.Persistence.Repositories
{
    public class FoodCategoriesRepository : BaseRepository<FoodCategory>, IFoodCategoriesRepository
    {
        public FoodCategoriesRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<FoodCategory> GetByName(string name) => await (from foodCategory in dbContext.Set<FoodCategory>()
                                                                             where foodCategory.Name == name
                                                                             select foodCategory).FirstOrDefaultAsync();
    }
}
