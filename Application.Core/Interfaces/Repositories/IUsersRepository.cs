using NUCAL.Application.Core.Entities;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Repositories
{
    public interface IUsersRepository: IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
