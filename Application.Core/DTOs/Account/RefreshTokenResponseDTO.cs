
namespace NUCAL.Application.Core.DTOs.Account
{
    public partial class RefreshTokenResponseDTO
    {
        public UserTokenDTO UserToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
