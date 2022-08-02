using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Serilog;

namespace ViolaTricolor.Configuration
{
    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <summary>
        /// Конфиг логгера
        /// </summary>
        public LoggerConfig Logger { get; set; }

        /// <summary>
        /// Конфиг мониторинга Вк
        /// </summary>
        public VkMonitoringConfig VkMonitoring { get; set; }

        /// <summary>
        /// Файл бд
        /// </summary>
        public string DbFileName { get; set; }

        private static readonly ILogger Log = Serilog.Log.ForContext<Config>();

        /// <summary>
        /// Загрузить конфигурацию
        /// </summary>
        /// <returns></returns>
        public static Config Load()
        {
            var config = MergeConfigs(
                LoadFromJson(Path.Combine(Directories.ConfigDirectory, "config.json")),
                LoadFromJson(Path.Combine(Directories.ConfigDirectory, "config.local.json")),
                CreateDefaultConfig()
            );

            return config;
        }

        /// <inheritdoc/>
        public void MergeWith(IConfig config)
        {
            var currentConfig = config as Config;
            Logger.MergeWith(currentConfig.Logger);
            VkMonitoring.MergeWith(currentConfig.VkMonitoring);
            DbFileName = !string.IsNullOrEmpty(currentConfig.DbFileName) ? currentConfig.DbFileName : DbFileName;
        }

        private static Config MergeConfigs(params Config[] configs)
        {
            var config = new Config
            {
                Logger = new LoggerConfig(),
                VkMonitoring = new VkMonitoringConfig()
            };

            foreach (var c in configs.Where(_ => _ != null))
            {
                config.MergeWith(c);
            }

            return config;
        }

        private static Config LoadFromJson(string filename)
        {
            var path = Path.Combine(Environment.CurrentDirectory, filename);
            path = Path.GetFullPath(path);

            if (!File.Exists(path))
            {
                Log.Error($"File \"{path}\" doesn't exist");
                return null;
            }

            try
            {
                var config = new Config
                {
                    Logger = new LoggerConfig(),
                    VkMonitoring = new VkMonitoringConfig()
                };

                var json = File.ReadAllText(path, Encoding.UTF8);
                JsonConvert.PopulateObject(json, config);
                Log.Information($"Loaded config \"{path}\"");
                return config;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to load config \"{path}\": {e.Message}");
                return null;
            }
        }

        private static Config CreateDefaultConfig()
        {
            return new Config
            {
                Logger = new LoggerConfig
                {
                    FileName = "ViolaTricolorLog",
                    FilePath = "Logs",
                    LimitFileSize = 128 * 1024 * 1024,
                    RollingInterval = RollingInterval.Day
                },
                VkMonitoring = new VkMonitoringConfig
                {
                    AutoImport = true,
                    Interval = new TimeSpan(0, 0, 30),
                    ServiceAccessKey = "",
                    MainUserId = null
                },
                DbFileName = "ViolaTricolor.db"
            };
        }
    }
}
