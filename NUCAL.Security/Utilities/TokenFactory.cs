using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NUCAL.Application.Core.DTOs;
using NUCAL.Security.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NUCAL.Security.Utilities
{
    public class TokenFactory : ITokenFactory
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private readonly IConfiguration configuration;

        public TokenFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UserTokenDTO BuildToken(ApplicationUser user, IList<string> roles)
        {
            List<Claim> claims = CreateClaims(user, roles);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_KEY"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expiration = DateTime.UtcNow.AddHours(10);
            var date = DateTime.Now;
            var dateUTC = DateTime.UtcNow;
            var expiration = DateTime.UtcNow.AddMinutes(1);
            var token = GenerateToken(claims, credentials, expiration);
            return GetResponse(token, expiration);
        }
        private List<Claim> CreateClaims(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
            return claims;
        }
        private JwtSecurityToken GenerateToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: credentials);
        }
        private UserTokenDTO GetResponse(JwtSecurityToken token, DateTime expiration)
        {
            var userToken = new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
            return userToken;
        }

        public string BuildRefreshToken()
        {
            var random = new byte[128];
            rngCsp.GetBytes(random);
            var refreshToken = Convert.ToBase64String(random);
            return refreshToken;
        }
    }
}
