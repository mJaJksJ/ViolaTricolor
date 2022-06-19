using Serilog;

namespace ViolaTricolor.Configuration
{
    /// <summary>
    /// Конфиг логгера
    /// </summary>
    public class LoggerConfig : IConfig
    {
        /// <summary>
        /// Имя файла логгера
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Лимит на размер файла
        /// </summary>
        public int LimitFileSize { get; set; }

        /// <summary>
        /// Папка сохранения файлов лога
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Интервал создания новых файлов 
        /// </summary>
        public RollingInterval? RollingInterval { get; set; }

        /// <inheritdoc/>
        public void MergeWith(IConfig config)
        {
            var currentConfig = config as LoggerConfig;
            FileName = !string.IsNullOrEmpty(currentConfig.FileName) ? currentConfig.FileName : FileName;
            LimitFileSize = currentConfig.LimitFileSize > 0 ? currentConfig.LimitFileSize : LimitFileSize;
            FilePath = !string.IsNullOrEmpty(currentConfig.FilePath) ? currentConfig.FilePath : FilePath;
            RollingInterval = currentConfig.RollingInterval.HasValue ? currentConfig.RollingInterval : RollingInterval;
        }
    }
}
