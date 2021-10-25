
using NUCAL.Application.Core.Interfaces.Repositories;

namespace NUCAL.Application.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IConsumedFoodsRepository ConsumedFoodsRepository { get; }
        IFoodCategoriesRepository FoodCategoriesRepository { get;  }
        IFoodsRepository FoodsRepository { get; }
        IUsersRepository UsersRepository { get; }

        void commit();
    }
}
