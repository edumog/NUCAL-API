using NUCAL.Application.Core.DTOs;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Services
{
    public interface IUsersManagerService
    {
        Task<ResponseDTO> AssignRoleToUser(RoleToUserDTO roleToUser);
        Task<ResponseDTO> RemoveRoleToUser(RoleToUserDTO roleToUser);
    }
}
