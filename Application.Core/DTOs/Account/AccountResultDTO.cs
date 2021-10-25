using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs.Account
{
    public partial class AccountResultDTO
    {
        public UserDTO User { get; set; }
        public IList<string> UserRoles { get; set; } = null;
        public string RefreshToken { get; set; } = "";
    }
}
