using Microsoft.EntityFrameworkCore;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace NUCAL.Persistence.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(DbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<User> GetByEmail(string email) => await (from user in dbContext.Set<User>()
                                                 where user.Email == email
                                                 select user).FirstOrDefaultAsync();
    }
}
