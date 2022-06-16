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

        public void MergeWith(IConfig config)
        {
            var currentConfig = config as VkMonitoringConfig;
            AutoImport = currentConfig.AutoImport.HasValue ? currentConfig.AutoImport : AutoImport;
            Interval = currentConfig.Interval.HasValue ? currentConfig.Interval : Interval;
        }
    }
}
