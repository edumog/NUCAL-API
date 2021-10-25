using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.Helpers;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Application.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Services
{
    public class UserManagerService: IUsersManagerService
    {
        private readonly IUsersManager usersManager;
        private readonly IMapper mapper;

        public UserManagerService(IUsersManager usersManager, IMapper mapper)
        {
            this.usersManager = usersManager;
            this.mapper = mapper;
        }

        public async Task<ResponseDTO> AssignRoleToUser(RoleToUserDTO roleToUser)
        {
            try
            {
                return await usersManager.AssignRoleToUser(roleToUser);

            }
            catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }

        public async Task<ResponseDTO> RemoveRoleToUser(RoleToUserDTO roleToUser)
        {
            try
            {
                return await usersManager.RemoveRoleToUser(roleToUser);
            }
            catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }
    }
}
