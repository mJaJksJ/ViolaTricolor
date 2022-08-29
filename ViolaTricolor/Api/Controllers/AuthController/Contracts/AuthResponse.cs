using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string VtUserId { get; set; }

        /// <summary>
        /// Id Vk пользователя
        /// </summary>
        [JsonProperty("vk_user_id")]
        [Required]
        public string VkUserId { get; set; }

        /// <summary>
        /// Никнейм VT пользователя
        /// </summary>
        [JsonProperty("username")]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        [JsonProperty("token")]
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// Тип токена
        /// </summary>
        [JsonProperty("token_type")]
        [Required]
        public string TokenType { get; set; }

        /// <summary>
        /// Срок действия токена
        /// </summary>
        [JsonProperty("validity_period")]
        [Required]
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [JsonProperty("roles")]
        [Required]
        public List<string> Roles { get; set; }
    }
}
