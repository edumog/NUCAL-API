using NUCAL.Application.Core.Interfaces;
using NUCAL.Application.Core.Interfaces.Repositories;
using NUCAL.Persistence.Contexts;
using NUCAL.Persistence.Repositories;

namespace NUCAL.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IConsumedFoodsRepository consumedFoodsRepository;
        private IFoodCategoriesRepository foodCategoriesRepository;
        private IFoodsRepository foodsRepository;
        private IUsersRepository users;

        public IConsumedFoodsRepository ConsumedFoodsRepository => consumedFoodsRepository ?? (consumedFoodsRepository = new ConsumedFoodsRepository(dbContext));

        public IFoodCategoriesRepository FoodCategoriesRepository => foodCategoriesRepository ?? (foodCategoriesRepository = new FoodCategoriesRepository(dbContext));

        public IFoodsRepository FoodsRepository => foodsRepository ?? (foodsRepository = new FoodsRepository(dbContext));

        public IUsersRepository UsersRepository => users ?? (users = new UsersRepository(dbContext));

        public void commit()
        {
            dbContext.SaveChanges();
        }
    }
}
