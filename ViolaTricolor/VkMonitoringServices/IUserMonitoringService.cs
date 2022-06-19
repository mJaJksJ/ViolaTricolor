using VkNet;
using VkNet.Model;

namespace ViolaTricolor.VkMonitoringServices
{
    /// <summary>
    /// Сервис запуска мониторинга
    /// </summary>
    public interface IUserMonitoringService
    {
        /// <summary>
        /// Обновить таймер автоимпорта
        /// </summary>
        void UpdateAutoImport();

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
