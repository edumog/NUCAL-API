using NUCAL.Application.Core.DTOs;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces
{
    public interface IUsersManager
    {
        Task<ResponseDTO> AssignRoleToUser(RoleToUserDTO roleToUser);
        Task<ResponseDTO> RemoveRoleToUser(RoleToUserDTO roleToUser);
    }
}
