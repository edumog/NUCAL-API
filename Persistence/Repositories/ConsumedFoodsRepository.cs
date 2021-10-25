using Microsoft.EntityFrameworkCore;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUCAL.Persistence.Repositories
{
    public class ConsumedFoodsRepository : BaseRepository<ConsumedFood>, IConsumedFoodsRepository
    {
        public ConsumedFoodsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ConsumedFood>> GetByUser(string idUser) => await (from c in dbContext.Set<ConsumedFood>()
                                                                     where c.IdUser == idUser
                                                                     select c).ToListAsync();

        public async Task<ConsumedFood> GetById(string idUser, DateTime date, byte numberOfPlate, string idFood) => await (from c in dbContext.Set<ConsumedFood>()
                                                                                                                           where
                                                                                                                           c.IdUser == idUser &&
                                                                                                                           c.Date.ToString() == date.ToString("yyyy-MM-dd") &&
                                                                                                                           c.NumberOfPlate == numberOfPlate &&
                                                                                                                           c.IdFood == idFood
                                                                                                                           select c).FirstOrDefaultAsync();
    }
}
