using NUCAL.Application.Core.DTOs;
using NUCAL.Security.Models;
using System.Collections.Generic;

namespace NUCAL.Security.Utilities
{
    public interface ITokenFactory
    {
        public UserTokenDTO BuildToken(ApplicationUser user, IList<string> roles);
        public string BuildRefreshToken();
    }
}
