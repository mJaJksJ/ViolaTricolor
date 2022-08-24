using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ViolaTricolor.Api.Controllers.AuthController.Contracts;
using ViolaTricolor.Configuration;
using ViolaTricolor.Database;
using ViolaTricolor.Database.Entities;

namespace ViolaTricolor.Services.AuthService
{
    /// <inheritdoc cref="IAuthService"/>
    public class AuthService : IAuthService
    {
        private readonly Config _config;
        private readonly DatabaseContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public AuthService(Config config, DatabaseContext context)
        {
            _context = context;
            _config = config;
        }

        /// <inheritdoc/>
        public (ClaimsIdentity, VTUser) Authorize(AuthRequest request)
        {
            var user = _context.VTUsers
                .Include(_ => _.VkUserId)
                .SingleOrDefault(u => u.Login.ToLower() == request.Login.ToLower());

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new Exception();
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"),
                new Claim("login", user.Login)
            };

            return (new ClaimsIdentity(claims), user);
        }

        /// <inheritdoc/>
        public (string token, DateTime expires) GenerateToken(IEnumerable<Claim> claims, VTUser user)
        {
            var now = DateTime.Now;
            var expires = now.AddSeconds(_config.AuthConfig.JwtLifetimeSeconds);

            var jwt = new JwtSecurityToken(
                _config.AuthConfig.JwtIssuer,
                _config.AuthConfig.JwtAudience,
                claims,
                now,
                expires,
                new SigningCredentials(
                    new SymmetricSecurityKey(_config.AuthConfig.JwtSecurityKey),
                    "HS256"
                )
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, expires);
        }

        /// <inheritdoc/>
        public void ChangePassword(ChangePasswordContract contract)
        {
            var user = _context.VTUsers.SingleOrDefault(u => u.Login.ToLower() == contract.Login.ToLower());

            if (user == null)
            {
                throw new Exception();
            }

            if (!BCrypt.Net.BCrypt.Verify(contract.Password, user.Password))
            {
                throw new Exception();
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(contract.NewPassword, SaltRevision.Revision2B);

            _context.SaveChanges();
        }
    }
}
