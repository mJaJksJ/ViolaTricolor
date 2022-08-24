using Newtonsoft.Json;

namespace ViolaTricolor.Api.Controllers.AuthController.Contracts
{
    /// <summary>
    /// Контракт изменения пароля
    /// </summary>
    public class ChangePasswordContract
    {
        /// <summary>
        /// Логин
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// Старый пароль
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        [JsonProperty("new_password")]
        public string NewPassword { get; set; }
    }
}
