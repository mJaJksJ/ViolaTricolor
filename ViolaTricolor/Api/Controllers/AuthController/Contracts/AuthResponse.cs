using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViolaTricolor.Api.Controllers.AuthController.Contracts
{
    /// <summary>
    /// Ответ авторизации
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Id VT пользователя
        /// </summary>
        [JsonProperty("vt_user_id")]
        public string VtUserId { get; set; }

        /// <summary>
        /// Id Vk пользователя
        /// </summary>
        [JsonProperty("vk_user_id")]
        public string VkUserId { get; set; }

        /// <summary>
        /// Никнейм VT пользователя
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Тип токена
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Срок действия токена
        /// </summary>
        [JsonProperty("validity_period")]
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }
}
