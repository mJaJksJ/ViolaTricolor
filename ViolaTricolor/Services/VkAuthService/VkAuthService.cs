using System;
using System.Linq;
using Serilog;
using ViolaTricolor.Configuration;
using ViolaTricolor.Database;
using ViolaTricolor.Database.Entities;
using VkNet;
using VkNet.Model;

namespace ViolaTricolor.Services.AuthService
{
    /// <inheritdoc cref="IVkAuthService"/>
    public class VkAuthService : IVkAuthService
    {
        private readonly Config _config;
        private readonly DatabaseContext _context;
        private static readonly ILogger Log = Serilog.Log.ForContext<VkAuthService>();

        /// <inheritdoc/>
        public VkApi GetVkApi { get; private set; }

        /// <inheritdoc/>
        public User GetVkUser { get; private set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public VkAuthService(Config config, DatabaseContext context)
        {
            // TODO: Привести логи к единому стилю
            _config = config;
            _context = context;

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

                GetVkUser = _config.VkMonitoring.MainUserId.HasValue
                    ? GetVkApi.Users.Get(new long[] { _config.VkMonitoring.MainUserId.Value }).FirstOrDefault()
                    : null;

                if (!_context.VkUsers.Any(_ => _.Id == GetVkUser.Id))
                {
                    var vtUser = _context.VTUsers.First(_ => _.Login == "admin");

                    var vkUser = _context.VkUsers.Add(new VkUser
                    {
                        Name = GetVkUser.FirstName,
                        Surname = GetVkUser.LastName,
                        Id = GetVkUser.Id,
                        VtUser = vtUser,
                    });

                    vtUser.VkUser = vkUser.Entity;

                    _context.SaveChanges();
                }

                if (GetVkUser != null)
                {
                    Log.Information($"Main user ${GetVkUser.Id} accessed");
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
