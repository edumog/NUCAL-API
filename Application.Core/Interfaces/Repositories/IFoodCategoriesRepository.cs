using NUCAL.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Repositories
{
    public interface IFoodCategoriesRepository: IRepository<FoodCategory>
    {
        Task<FoodCategory> GetByName(string name);
    }
}
