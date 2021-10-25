using Microsoft.AspNetCore.Identity;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Security.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUCAL.Security.Services
{
    public class UsersManager : IUsersManager
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersManager(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ResponseDTO> AssignRoleToUser(RoleToUserDTO roleToUser)
        {
            var user = await userManager.FindByIdAsync(roleToUser.UserId);
            if(user == null)
            {
                return GetInvalidResponse();
            }
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, roleToUser.RoleName));
            await userManager.AddToRoleAsync(user, roleToUser.RoleName.Normalize());
            return GetSuccessfulResponse();
        }

        public async Task<ResponseDTO> RemoveRoleToUser(RoleToUserDTO roleToUser)
        {
            var user = await userManager.FindByIdAsync(roleToUser.UserId);
            if (user == null)
            {
                return GetInvalidResponse();
            }
            await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, roleToUser.RoleName));
            await userManager.RemoveFromRoleAsync(user, roleToUser.RoleName);
            return GetSuccessfulResponse();
        }

        private ResponseDTO GetInvalidResponse()
        {
            ResponseDTO response = new ResponseDTO();
            response.Succeeded = false;
            response.Errors = new List<ErrorDTO>();
            response.Errors.Add(new ErrorDTO()
            {
                Code = "NotFound",
                Description = "UserNotFound"
            });
            return response;
        }
        private ResponseDTO GetSuccessfulResponse()
        {
            return new ResponseDTO() { Succeeded = true };
        }
    }
}
