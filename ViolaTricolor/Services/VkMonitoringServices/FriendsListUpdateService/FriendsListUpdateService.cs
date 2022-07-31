using ViolaTricolor.Services.AuthService;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace ViolaTricolor.Services.VkMonitoringServices.FriendsListUpdateService
{
    /// <inheritdoc cref="IFriendsListUpdateService"/>
    public class FriendsListUpdateService : IFriendsListUpdateService
    {
        private readonly IVkAuthService _vkAuthService;

        /// <summary>
        /// .ctor
        /// </summary>
        public FriendsListUpdateService(IVkAuthService vkAuthService)
        {
            _vkAuthService = vkAuthService;
        }

        /// <inheritdoc/>
        public void CheckFriendsList()
        {
            var friends = _vkAuthService.GetVkApi.Friends.Get(new FriendsGetParams { UserId = _vkAuthService.GetMainUser.Id, Fields = ProfileFields.Nickname });
        }
    }
}
