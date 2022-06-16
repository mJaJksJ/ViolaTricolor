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
    public class UserMonitoringService : IUserMonitoringService
    {
        private readonly Config _config;
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly VkApi _vkApi;

        private Timer _timer;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserMonitoringService>();

        private int MonitoringTime => _config.VkMonitoring.Interval.HasValue
            ? (int)_config.VkMonitoring.Interval.Value.TotalMilliseconds
            :  30 * 60 * 1000;

        public UserMonitoringService(
            Config config,
            IServiceScopeFactory scopeFactory)
        {
            _config = config;
            _scopeFactory = scopeFactory;
            _vkApi = new VkApi();


            Start();
        }

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

        public void Update()
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
