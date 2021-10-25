using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Account;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<ResponseItemDTO<AccountResultDTO>> CreateUser(UserCreationDTO user);
        Task<ResponseItemDTO<AccountResultDTO>> Login(LoginDTO credentials);
        Task<ResponseItemDTO<RefreshTokenResponseDTO>> RefreshToken(string currentToken, string idUser);
    }
}
