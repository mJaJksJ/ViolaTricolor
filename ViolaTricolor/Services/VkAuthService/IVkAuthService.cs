using VkNet;
using VkNet.Model;

namespace ViolaTricolor.Services.AuthService
{
    /// <summary>
    /// Сервис авторизации в сервисах ВК
    /// </summary>
    public interface IVkAuthService
    {
        /// <summary>
        /// Получить контекст вк-апи
        /// </summary>
        VkApi GetVkApi { get; }

        /// <summary>
        /// Получить основного пользователя
        /// </summary>
        User GetMainUser { get; }
    }
}
