using Microsoft.AspNetCore.Identity;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Account;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Security.Models;
using NUCAL.Security.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Security.Services
{
    public class Account : IAccount
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenFactory tokenFactory;
        private readonly IMapper mapper;

        public Account(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper, ITokenFactory tokenFactory)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenFactory = tokenFactory;
            this.mapper = mapper;
        }

        public async Task<ResponseItemDTO<AccountResultDTO>> CreateUser(UserSecurityDTO user, bool keepLoggedIn)
        {
            ApplicationUser newUser = new ApplicationUser() { UserName = user.Email, Email = user.Email };
            var result = await userManager.CreateAsync(newUser, user.Password);
            return await ProcessResult(result, newUser, keepLoggedIn);
        }
        private async Task<ResponseItemDTO<AccountResultDTO>> ProcessResult(IdentityResult result, ApplicationUser user, bool keepLoggedIn)
        {
            return (result.Succeeded) ? await GetResponse(keepLoggedIn, user) : new ResponseItemDTO<AccountResultDTO> { Succeeded = false, StatusCode = 400, Errors = MapErrorList(result.Errors) };
        }
        private List<ErrorDTO> MapErrorList(IEnumerable<IdentityError> errors)
        {
            List<ErrorDTO> errorsList = new List<ErrorDTO>();
            foreach (var error in errors)
            {
                errorsList.Add(new ErrorDTO() { Code = error.Code, Description = error.Description });
            }
            return errorsList;
        }

        public async Task<ResponseItemDTO<AccountResultDTO>> Login(LoginDTO credentials)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: false);
            return await ProcessResult(result, credentials.Email, credentials.KeepLoggedIn);
        }
        private async Task<ResponseItemDTO<AccountResultDTO>> ProcessResult(SignInResult result, string email, bool keepLoggedIn)
        {
            return (result.Succeeded) ? await GetSuccessfulResponse(email, keepLoggedIn) : GetBadResponse<AccountResultDTO>(400, "400", "Login fail");
        }
        private async Task<ResponseItemDTO<AccountResultDTO>> GetSuccessfulResponse(string email, bool keepLoggedIn)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            ResponseItemDTO<AccountResultDTO> response = await GetResponse(keepLoggedIn, user);
            return response;
        }
        private async Task<UserTokenDTO> GetUserToken(ApplicationUser user)
        {
            IList<string> roles = await userManager.GetRolesAsync(user);
            return tokenFactory.BuildToken(user, roles);
        }


        private async Task<ResponseItemDTO<AccountResultDTO>> GetResponse(bool keepLoggedIn, ApplicationUser user)
        {
            ResponseItemDTO<AccountResultDTO> response = new ResponseItemDTO<AccountResultDTO>
            {
                Succeeded = true,
                StatusCode = 200,
                Item = await GetItemForResponse(keepLoggedIn, user)
            };
            return response;
        }
        private async Task<AccountResultDTO> GetItemForResponse(bool keepLoggedIn, ApplicationUser user)
        {
            AccountResultDTO item = new AccountResultDTO
            {
                User = mapper.Map<ApplicationUser, UserDTO>(user),
                UserRoles = await userManager.GetRolesAsync(user),
                RefreshToken = (keepLoggedIn) ? await RefreshToken(user) : await RemoveRefreshToken(user),
            };
            item.User.Token = await GetUserToken(user);
            return item;
        }
        private async Task<string> RemoveRefreshToken(ApplicationUser user)
        {
            await userManager.RemoveAuthenticationTokenAsync(user, "nucal", "refreshToken");
            return "";
        }

        public async Task<ResponseItemDTO<RefreshTokenResponseDTO>> RefreshToken(string currentToken, string idUser)
        {
            ApplicationUser user = await userManager.FindByIdAsync(idUser);
            return (user != null) ? await GetSuccessfulResponse(currentToken, idUser, user) : GetBadResponse<RefreshTokenResponseDTO>(404, "404");
        }
        private async Task<ResponseItemDTO<RefreshTokenResponseDTO>> GetSuccessfulResponse(string currenToken, string idUser, ApplicationUser user)
        {
            return new ResponseItemDTO<RefreshTokenResponseDTO>
            {
                Succeeded = true,
                StatusCode = 200,
                Item = await GenerateTokens(user, currenToken)
            };
        }
        private async Task<RefreshTokenResponseDTO> GenerateTokens(ApplicationUser user, string currentToken)
        {
            string refreshToken = await userManager.GetAuthenticationTokenAsync(user, "nucal", "refreshToken");
            if (refreshToken != null && currentToken == refreshToken)
            {
                UserTokenDTO userToken = await GetUserToken(user);
                string newRefreshToken = await RefreshToken(user);
                return new RefreshTokenResponseDTO { UserToken = userToken, RefreshToken = newRefreshToken };
            }
            return null;
        }

        private async Task<string> RefreshToken(ApplicationUser user)
        {
            string refreshToken = tokenFactory.BuildRefreshToken();
            var result = await userManager.SetAuthenticationTokenAsync(user, "nucal", "refreshToken", refreshToken);
            if (result.Succeeded)
                return refreshToken;
            return null;
        }

        public void RemoveUser(string userName)
        {
            ApplicationUser user = userManager.FindByNameAsync(userName).Result;
            if (user != null)
            {
                userManager.DeleteAsync(user);
            }
        }

        private ResponseItemDTO<T> GetBadResponse<T>(int StatusCode, string code = "", string description = "")
        {
            ResponseItemDTO<T> response = new ResponseItemDTO<T>
            {
                StatusCode = StatusCode,
                Errors = new List<ErrorDTO>(),
            };
            response.Errors.Add(new ErrorDTO() { Code = code, Description = description });
            return response;
        }
    }
}
