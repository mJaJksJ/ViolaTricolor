namespace ViolaTricolor.Configuration
{
    /// <summary>
    /// Конфиг
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Объединить данные с ...
        /// </summary>
        /// <param name="config">Конфиг для объединения</param>
        void MergeWith(IConfig config);
    }
}
