using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace NUCAL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersManagerController: CustomBaseController
    {
        private readonly IUsersManagerService usersManagerService;

        public UsersManagerController(IUsersManagerService usersManagerService)
        {
            this.usersManagerService = usersManagerService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("AssignRole", Name = "AssignRole")]
        public async Task<ActionResult<ResponseDTO>> AssignRoleToUser([FromBody] RoleToUserDTO roleToUser)
        {
            return GetResponse(await usersManagerService.AssignRoleToUser(roleToUser));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [Route("RemoveRole", Name = "RemoveRole")]
        public async Task<ActionResult<ResponseDTO>> RemoveRoleToUser([FromBody] RoleToUserDTO roleToUser)
        {
            return GetResponse(await usersManagerService.RemoveRoleToUser(roleToUser));
        }
    }
}
