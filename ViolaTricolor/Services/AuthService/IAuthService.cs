using System;
using System.Collections.Generic;
using System.Security.Claims;
using ViolaTricolor.Api.Controllers.AuthController.Contracts;
using ViolaTricolor.Database.Entities;

namespace ViolaTricolor.Services.AuthService
{
    /// <summary>
    /// Сервис авторизации
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <param name="request">Запрос авторизации</param>
        /// <returns>(Удостоверения на основе требований, Пользователь ViolaTricolor)</returns>
        (ClaimsIdentity, VTUser) Authorize(AuthRequest request);

        /// <summary>
        /// Создать токен
        /// </summary>
        /// <param name="claims">Требования</param>
        /// <param name="user"></param>
        /// <returns></returns>
        (string token, DateTime expires) GenerateToken(IEnumerable<Claim> claims, VTUser user);

        /// <summary>
        /// Сменить пароль
        /// </summary>
        /// <param name="contract">Контракт изменения пароля</param>
        void ChangePassword(ChangePasswordContract contract);
    }
}
