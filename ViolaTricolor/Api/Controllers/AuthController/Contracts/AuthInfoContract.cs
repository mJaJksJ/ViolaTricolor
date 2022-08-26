using Newtonsoft.Json;

namespace ViolaTricolor.Api.Controllers.AuthController.Contracts
{
    /// <summary>
    /// Авторизационная информация
    /// </summary>
    public class AuthInfoContract
    {
        /// <summary>
        /// Авторизирован ли пользователь
        /// </summary>
        [JsonProperty("is_authorized")]
        public bool IsAuthorized { get; set; }
    }
}
