using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Account;
using NUCAL.Application.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace NUCAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: CustomBaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseItemDTO<AccountResultDTO>>> RegisterUser([FromBody] UserCreationDTO user)
        {
            var registerResult = await accountService.CreateUser(user);
            return GetResponse(registerResult, registerResult.Item);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseItemDTO<AccountResultDTO>>> Login([FromBody] LoginDTO credentials)
        {
            var loginResult = await accountService.Login(credentials);
            return GetResponse(loginResult, ((loginResult.Item != null) ? loginResult.Item : null));
        }

        [HttpPost("Refresh-token")]
        public async Task<ActionResult<ResponseItemDTO<RefreshTokenResponseDTO>>> RefreshToken([FromBody] RefreshTokenRequestDTO refreshTokenRequest)
        {
            var result = await accountService.RefreshToken(refreshTokenRequest.RefreshToken, refreshTokenRequest.UserId);
            return GetResponse(result, result.Item);
        }
    }
}
