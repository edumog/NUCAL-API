using Microsoft.EntityFrameworkCore;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUCAL.Persistence.Repositories
{
    public class FoodsRepository: BaseRepository<Food>, IFoodsRepository
    {
        public FoodsRepository(DbContext dbContext): base(dbContext)
        {
        }

        public async Task<Food> GetByName(string name) => await (from food in dbContext.Set<Food>()
                                                          where food.Name == name
                                                          select food).FirstOrDefaultAsync();



        public async Task<Food> GetByIdWithDetails(string id) => await (from food in dbContext.Set<Food>() where food.Id == id select food)
            .Include(x => x.FoodInCategories).ThenInclude(x => x.FoodCategory)
            .Include(x => x.FattyAcidsAndCholesterol)
            .Include(x => x.Macronutrients)
            .Include(x => x.Minerals)
            .Include(x => x.ReferenceMeasurements)
            .Include(x => x.Vitamins)
            .FirstOrDefaultAsync();

        public async Task<List<Food>> GetAllWithCategories() => await dbContext.Set<Food>().Include(x => x.FoodInCategories).ToListAsync();

    }
}
