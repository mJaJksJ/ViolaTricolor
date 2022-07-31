using Serilog;
using System;
using System.Linq;
using ViolaTricolor.Configuration;
using VkNet;
using VkNet.Model;

namespace ViolaTricolor.Services.AuthService
{
    /// <inheritdoc cref="IVkAuthService"/>
    public class VkAuthService : IVkAuthService
    {
        private readonly Config _config;
        private readonly VkApi _vkApi;
        private readonly User _mainUser;

        /// <summary>
        /// .ctor
        /// </summary>
        public VkAuthService(Config config)
        {
            // TODO: Привести логи к единому стилю
            _config = config;
            _vkApi = new VkApi();
            _vkApi.SetLanguage(VkNet.Enums.Language.Ru);

            if (!string.IsNullOrEmpty(_config.VkMonitoring.ServiceAccessKey))
            {
                _vkApi.Authorize(new ApiAuthParams { AccessToken = _config.VkMonitoring.ServiceAccessKey });
                if (string.IsNullOrEmpty(_vkApi.Token))
                {
                    Log.Error("AccessToken didn\'t got");
                    throw new Exception("Неверный токен");
                }
                else
                {
                    Log.Information("AccesToken got succesful");
                }

                _mainUser = _config.VkMonitoring.MainUserId.HasValue
                    ? _vkApi.Users.Get(new long[] { _config.VkMonitoring.MainUserId.Value }).FirstOrDefault()
                    : null;

                if (_mainUser != null)
                {
                    Log.Information($"Main user ${_mainUser.Id} accessed");
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

        /// <inheritdoc/>
        public VkApi GetVkApi => _vkApi;

        /// <inheritdoc/>
        public User GetMainUser => _mainUser;
    }
}
