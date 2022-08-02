using System.IO;
using System.Reflection;

namespace ViolaTricolor
{
    /// <summary>
    /// Пути к основным папкам
    /// </summary>
    public static class Directories
    {
        /// <summary>
        /// Путь к конфигу
        /// </summary>
        public static string ConfigDirectory { get; private set; }

        /// <summary>
        /// Папка с exe файлом
        /// </summary>
        public static string RunDirectory { get; private set; }

        static Directories()
        {
            RunDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ConfigDirectory = RunDirectory;
        }
    }
}
