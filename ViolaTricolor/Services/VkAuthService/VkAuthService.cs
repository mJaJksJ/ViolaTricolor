using System;
using System.Linq;
using Serilog;
using ViolaTricolor.Configuration;
using VkNet;
using VkNet.Model;

namespace ViolaTricolor.Services.AuthService
{
    /// <inheritdoc cref="IVkAuthService"/>
    public class VkAuthService : IVkAuthService
    {
        private readonly Config _config;

        /// <inheritdoc/>
        public VkApi GetVkApi { get; private set; }

        /// <inheritdoc/>
        public User GetMainUser { get; private set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public VkAuthService(Config config)
        {
            // TODO: Привести логи к единому стилю
            _config = config;
            GetVkApi = new VkApi();
            GetVkApi.SetLanguage(VkNet.Enums.Language.Ru);

            if (!string.IsNullOrEmpty(_config.VkMonitoring.ServiceAccessKey))
            {
                GetVkApi.Authorize(new ApiAuthParams { AccessToken = _config.VkMonitoring.ServiceAccessKey });
                if (string.IsNullOrEmpty(GetVkApi.Token))
                {
                    Log.Error("AccessToken didn\'t got");
                    throw new Exception("Неверный токен");
                }
                else
                {
                    Log.Information("AccesToken got succesful");
                }

                GetMainUser = _config.VkMonitoring.MainUserId.HasValue
                    ? GetVkApi.Users.Get(new long[] { _config.VkMonitoring.MainUserId.Value }).FirstOrDefault()
                    : null;

                if (GetMainUser != null)
                {
                    Log.Information($"Main user ${GetMainUser.Id} accessed");
                }
                else
                {
                    Log.Warning($"Main user not accessed");
                }
            }
            else
            {
                Log.Error("Auth failed: service access key is empty");
            }
        }
    }
}
