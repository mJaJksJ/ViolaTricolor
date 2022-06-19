using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using ViolaTricolor.Configuration;
using VkNet;
using VkNet.Model;

namespace ViolaTricolor.VkMonitoringServices
{
    /// <inheritdoc cref="IUserMonitoringService"/>
    public class UserMonitoringService : IUserMonitoringService
    {
        private readonly Config _config;

        private readonly VkApi _vkApi;
        private readonly User _mainUser;

        private Timer _timer;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserMonitoringService>();

        private int MonitoringTime => _config.VkMonitoring.Interval.HasValue
            ? (int)_config.VkMonitoring.Interval.Value.TotalMilliseconds
            :  30 * 60 * 1000;

        /// <summary>
        /// .ctor
        /// </summary>
        public UserMonitoringService(
            Config config)
        {
            _config = config;
            _vkApi = new VkApi();

            if (!string.IsNullOrEmpty(_config.VkMonitoring.VkAppKey))
            {
                _vkApi.Authorize(new ApiAuthParams { AccessToken = _config.VkMonitoring.VkAppKey });
                if (string.IsNullOrEmpty(_vkApi.Token))
                {
                    Log.Error("AccessToken didn\'t got");
                    throw new Exception("Неверный токен");
                }
                else
                {
                    Log.Error("AccesToken got succesful");
                }

                _mainUser = _config.VkMonitoring.MainUserId.HasValue
                    ? _vkApi.Users.Get(new long[] { _config.VkMonitoring.MainUserId.Value }).FirstOrDefault()
                    : null;

                if(_mainUser != null)
                {
                    Log.Information($"Main user ${_mainUser} accessed");
                }
                else
                {
                    Log.Warning($"Main user not accessed");
                }
            }

            Start();
        }

        /// <inheritdoc/>
        public VkApi GetVkApi => _vkApi;

        /// <inheritdoc/>
        public User GetMainUser => _mainUser;

        private void Start()
        {
            Log.Information("Auto Import Service is starting.");

            if (_config.VkMonitoring.AutoImport.Value)
            {
                _timer = new Timer(TimerCallback, null, MonitoringTime, Timeout.Infinite);
            }
            else
            {
                _timer = new Timer(TimerCallback, null, Timeout.Infinite, 0);
            }
        }

        /// <inheritdoc/>
        public void UpdateAutoImport()
        {
            if (_config.VkMonitoring?.AutoImport != null && _config.VkMonitoring.AutoImport.Value)
            {
                _timer?.Change(MonitoringTime, Timeout.Infinite);
            }
            else
            {
                _timer?.Change(Timeout.Infinite, 0);
            }
        }

        private void TimerCallback(object _)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                RunMonitoring();
            }
            catch (Exception e)
            {
                Log.Error(e, "Error monitoring");
            }
            finally
            {
                _timer.Change(MonitoringTime, Timeout.Infinite);
            }
        }


        private void RunMonitoring()
        {

        }
    }
}
