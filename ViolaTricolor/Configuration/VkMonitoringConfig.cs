using System;

namespace ViolaTricolor.Configuration
{
    /// <summary>
    /// Конфиг мониторинга Вк
    /// </summary>
    public class VkMonitoringConfig : IConfig
    {
        /// <summary>
        /// Автоматический импорт
        /// </summary>
        public bool? AutoImport { get; set; }

        /// <summary>
        /// Интервал мониторинга
        /// </summary>
        public TimeSpan? Interval { get; set; }

        /// <summary>
        /// Ключ приложения Вк
        /// </summary>
        public string ServiceAccessKey { get; set; }

        /// <summary>
        /// Id основного пользователя
        /// </summary>
        public long? MainUserId { get; set; }

        /// <inheritdoc/>
        public void MergeWith(IConfig config)
        {
            var currentConfig = config as VkMonitoringConfig;
            AutoImport = currentConfig.AutoImport.HasValue ? currentConfig.AutoImport : AutoImport;
            Interval = currentConfig.Interval.HasValue ? currentConfig.Interval : Interval;
            ServiceAccessKey = !string.IsNullOrEmpty(currentConfig.ServiceAccessKey) ? currentConfig.ServiceAccessKey : ServiceAccessKey;
            MainUserId = currentConfig.MainUserId.HasValue ? currentConfig.MainUserId : MainUserId;
        }
    }
}
