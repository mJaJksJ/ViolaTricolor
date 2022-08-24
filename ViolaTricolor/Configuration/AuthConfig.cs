namespace ViolaTricolor.Configuration
{
    /// <summary>
    /// Конфиг авторизации
    /// </summary>
    public class AuthConfig : IConfig
    {
        /// <summary>
        /// Секретный ключ токена
        /// </summary>
        public byte[] JwtSecurityKey { get; set; }

        /// <summary>
        /// Время жизни токена
        /// </summary>
        public int JwtLifetimeSeconds { get; set; }

        /// <summary>
        /// Издатель токена
        /// </summary>
        public string JwtIssuer { get; set; }

        /// <summary>
        /// Пользователи токена
        /// </summary>
        public string JwtAudience { get; set; }

        /// <inheritdoc/>
        public void MergeWith(IConfig config)
        {
            var currentConfig = config as AuthConfig;
            JwtSecurityKey = currentConfig.JwtSecurityKey.Length > 0 ? currentConfig.JwtSecurityKey : JwtSecurityKey;
            JwtLifetimeSeconds = currentConfig.JwtLifetimeSeconds > 0 ? currentConfig.JwtLifetimeSeconds : JwtLifetimeSeconds;
            JwtIssuer = !string.IsNullOrEmpty(currentConfig.JwtIssuer) ? currentConfig.JwtIssuer : JwtIssuer;
            JwtAudience = !string.IsNullOrEmpty(currentConfig.JwtAudience) ? currentConfig.JwtAudience : JwtAudience;
        }
    }
}
