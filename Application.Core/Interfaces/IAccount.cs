using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Account;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces
{
    public interface IAccount
    {
        Task<ResponseItemDTO<AccountResultDTO>> CreateUser(UserSecurityDTO user, bool KeepLoggedIn);
        Task<ResponseItemDTO<AccountResultDTO>> Login(LoginDTO credentials);
        Task<ResponseItemDTO<RefreshTokenResponseDTO>> RefreshToken(string currentToken, string idUser);
        void RemoveUser(string userName);
    }
}
