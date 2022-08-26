using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViolaTricolor.Api.Controllers.AuthController.Contracts;
using ViolaTricolor.Configuration;
using ViolaTricolor.Database.Entities;
using ViolaTricolor.Services.AuthService;

namespace NSD.TransitAgent.API.Controllers.Authorization
{
    /// <summary>
    /// Авторизация
    /// </summary>
    public sealed class AuthController : Controller
    {
        private readonly Config _config;
        private readonly IAuthService _authService;

        /// <summary>
        /// .ctor
        /// </summary>
        public AuthController(
            Config config,
            IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        /// <summary>
        /// Вход в учетную запись
        /// </summary>
        /// <param name="request">Запрос авторизации</param>
        /// <returns>Ответ авторизации</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("~/api/authorize/login"), AllowAnonymous]
        [ProducesResponseType(typeof(AuthResponse), 200)]
        public IActionResult Authorize([FromBody] AuthRequest request)
        {
            ClaimsIdentity identity;
            VTUser user;

            try
            {
                (identity, user) = _authService.Authorize(request);
            }
            catch
            {
                throw new Exception();
            }

            if (identity == null)
            {
                throw new Exception();
            }

            var (token, expires) = _authService.GenerateToken(identity.Claims, user);

            var roles = identity.Claims
                .Where(_ => _.Type == identity.RoleClaimType)
                .Select(_ => _.Value).ToList();

            var userId = identity.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value;

            return Ok(new AuthResponse
            {
                VtUserId = userId,
                VkUserId = user.VkUserId.ToString(),
                Username = identity.Name,
                Token = token,
                TokenType = JwtBearerDefaults.AuthenticationScheme,
                ValidityPeriod = expires,
                Roles = roles
            });
        }

        /// <summary>
        /// Выход из учетной записи
        /// </summary>
        [Authorize]
        [HttpPost("~/api/authorize/logout")]
        [ProducesResponseType(typeof(OkResult), 200)]
        public IActionResult LogOut()
        {
            Response.Headers.Add("Clear-Site-Data", "\"cache\", \"cookies\"");
            return Ok();
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="contract">Контракт изменения пароля</param>
        [Authorize]
        [HttpPost("~/api/authorize/change-password")]
        [ProducesResponseType(typeof(OkResult), 200)]
        public IActionResult ChangePassword([FromBody] ChangePasswordContract contract)
        {
            _authService.ChangePassword(contract);
            return Ok();
        }

        /// <summary>
        /// Получить авторизационную информацию
        /// </summary>
        [HttpGet("~/api/authorize/info"), AllowAnonymous]
        [ProducesResponseType(typeof(AuthInfoContract), 200)]
        public IActionResult GetAuthInfo()
        {
            var result = new AuthInfoContract
            {
                IsAuthorized = User.Identity.IsAuthenticated
            };

            return Ok(result);
        }
    }
}
