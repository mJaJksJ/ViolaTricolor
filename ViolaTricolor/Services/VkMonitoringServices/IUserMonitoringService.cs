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
        /// Запуск сервиса
        /// </summary>
        void Start();
    }
}
