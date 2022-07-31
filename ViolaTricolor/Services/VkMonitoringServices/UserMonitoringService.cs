using System;
using System.Threading;
using Serilog;
using ViolaTricolor.Configuration;
using ViolaTricolor.Services.VkMonitoringServices.FriendsListUpdateService;

namespace ViolaTricolor.VkMonitoringServices
{
    /// <inheritdoc cref="IUserMonitoringService"/>
    public class UserMonitoringService : IUserMonitoringService, IDisposable
    {
        private readonly Config _config;
        private readonly IFriendsListUpdateService _friendsListUpdateService;

        private Timer _timer;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserMonitoringService>();

        /// <summary>
        /// .ctor
        /// </summary>
        public UserMonitoringService(Config config, IFriendsListUpdateService friendsListUpdateService)
        {
            _config = config;
            _friendsListUpdateService = friendsListUpdateService;
        }

        private int MonitoringTime => _config.VkMonitoring.Interval.HasValue
            ? (int)_config.VkMonitoring.Interval.Value.TotalMilliseconds
            : 30 * 60 * 1000;

        /// <inheritdoc/>
        public void Start()
        {
            Log.Information("User monitoring service is starting");

            if (_config.VkMonitoring.AutoImport.Value)
            {
                _timer = new Timer(TimerCallback, null, 0, MonitoringTime);
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
            try
            {
                RunMonitoring();
            }
            catch (Exception e)
            {
                Log.Error(e, "Error monitoring");
            }
        }

        private void RunMonitoring()
        {
            _friendsListUpdateService.CheckFriendsList();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The bulk of the clean-up code
        /// </summary>
        /// <param name="disposing">Dispose if true</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Dispose();
            }
        }
    }
}
