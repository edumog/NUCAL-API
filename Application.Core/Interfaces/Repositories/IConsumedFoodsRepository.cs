using NUCAL.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Repositories
{
    public interface IConsumedFoodsRepository: IRepository<ConsumedFood>
    {
        Task<List<ConsumedFood>> GetByUser(string idUser);
        Task<ConsumedFood> GetById(string idUser, DateTime date, byte numberOfPlate, string idFood);
    }
}
