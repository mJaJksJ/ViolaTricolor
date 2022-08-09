using ViolaTricolor.Enums;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Новость обновления списков друзей
    /// </summary>
    public class FriendsListUpdateNew : INewsContract
    {
        /// <summary>
        /// Типы новостей
        /// </summary>
        public NewsType NewsType => NewsType.FriendsListUpdate;

        /// <summary>
        /// Кто
        /// </summary>
        public VkUserContract Who { get; set; }

        /// <summary>
        /// Кого
        /// </summary>
        public VkUserContract Whom { get; set; }

        /// <summary>
        /// Отношение между вк пользователями
        /// </summary>
        public VkUserRelationsStatus VkUserRelationsStatus { get; set; }
    }
}
