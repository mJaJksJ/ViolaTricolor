using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ViolaTricolor.Configuration
{
    public class Config : IConfig, IMergeable
    {
        /// <summary>
        /// Конфиг логгера
        /// </summary>
        public LoggerConfig Logger { get; set; }

        private static readonly Serilog.ILogger Log = Serilog.Log.ForContext<Config>();

        public static Config Load()
        {
            var config = MergeConfigs(
                LoadFromJson("config.json"),
                LoadFromJson("config.local.json"),
                CreateDefaultConfig()
            );

            return config;
        }

        public void MergeWith(IConfig config)
        {
            var currentConfig = config as Config;
            Logger.MergeWith(currentConfig.Logger);
        }

        private static Config MergeConfigs(params Config[] configs)
        {
            var config = new Config
            {
                Logger = new LoggerConfig()
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
                    Logger = new LoggerConfig()
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
                }
            };
        }
    }
}
