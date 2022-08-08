using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ViolaTricolor.Database;
using ViolaTricolor.Database.Entities;
using ViolaTricolor.Enums;
using ViolaTricolor.Services.AuthService;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace ViolaTricolor.Services.VkMonitoringServices.FriendsListUpdateService
{
    /// <inheritdoc cref="IFriendsListUpdateService"/>
    public class FriendsListUpdateService : IFriendsListUpdateService
    {
        private readonly IVkAuthService _vkAuthService;
        private readonly DatabaseContext _context;

        private static readonly ILogger Log = Serilog.Log.ForContext<FriendsListUpdateService>();

        /// <summary>
        /// .ctor
        /// </summary>
        public FriendsListUpdateService(IVkAuthService vkAuthService, DatabaseContext context)
        {
            _vkAuthService = vkAuthService;
            _context = context;
        }

        /// <inheritdoc/>
        public void CheckFriendsList()
        {
            Log.Information("Start CheckFriendsList");

            var friends = _vkAuthService.GetVkApi.Friends.Get(new FriendsGetParams { UserId = _vkAuthService.GetVkUser.Id, Fields = ProfileFields.Nickname }).ToDictionary(_ => _.Id);

            var curDateTime = DateTime.Now;

            var oldFriends = _context.VkFriends
                .Include(_ => _.FirstFriend)
                .Include(_ => _.SecondFriend)
                .Where(_ => _.FirstFriendId == _vkAuthService.GetVkUser.Id || _.SecondFriendId == _vkAuthService.GetVkUser.Id)
                .Select(_ => _.FirstFriendId == _vkAuthService.GetVkUser.Id ? _.SecondFriend : _.FirstFriend);

            var user = _context.VkUsers
                .Include(_ => _.VtUser)
                .FirstOrDefault(_ => _.Id == _vkAuthService.GetVkUser.Id);

            // Проверяем были ли удаления из старых друзей
            foreach (var oldFriend in oldFriends)
            {
                if (!friends.ContainsKey(oldFriend.Id))
                {
                    var record = _context.FriendsJournals
                        .Add(new FriendsJournal
                        {
                            Who = user,
                            Whom = oldFriend,
                            DateTime = curDateTime,
                            RelationsStatus = VkUserRelationsStatus.Delete
                        });

                    var deletingFriends = _context.VkFriends.Where(_ =>
                    (_.FirstFriendId == user.Id && _.SecondFriendId == oldFriend.Id) ||
                    (_.FirstFriendId == oldFriend.Id && _.SecondFriendId == user.Id));

                    _context.Remove(deletingFriends);

                    _context.SaveChanges();
                    Log.Information(record.Entity.ToString());
                }
                else
                {
                    // далее проверяем список друзей уже без oldFriend
                    friends.Remove(oldFriend.Id);
                }
            }

            // Если в friends кто-то остался - это новые друзья
            {
                foreach (var friend in friends)
                {
                    var vkUser = _context.VkUsers
                        .AsNoTracking()
                        .FirstOrDefault(_ => _.Id == friend.Key);

                    VkUser addedVkUser = null;

                    if (vkUser == null)
                    {
                        var newVkUser = new VkUser
                        {
                            Name = friend.Value.FirstName,
                            Surname = friend.Value.LastName,
                            Id = friend.Value.Id
                        };

                        addedVkUser = _context.VkUsers.Add(newVkUser).Entity;
                    }

                    var record = _context.FriendsJournals.Add(new FriendsJournal
                    {
                        Who = user,
                        Whom = vkUser ?? addedVkUser,
                        DateTime = curDateTime,
                        RelationsStatus = VkUserRelationsStatus.Add
                    });

                    _context.VkFriends.Add(new VkFriend
                    {
                        FirstFriend = user,
                        SecondFriend = vkUser ?? addedVkUser
                    });

                    _context.SaveChanges();
                    Log.Information(record.Entity.ToString());
                }
            }

            Log.Information("Finish CheckFriendsList");
        }
    }
}
