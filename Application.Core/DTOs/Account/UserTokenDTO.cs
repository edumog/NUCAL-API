using System;

namespace NUCAL.Application.Core.DTOs
{
    public partial class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
