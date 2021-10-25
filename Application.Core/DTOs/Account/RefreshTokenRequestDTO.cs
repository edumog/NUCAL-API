using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs.Account
{
    public partial class RefreshTokenRequestDTO
    {
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
