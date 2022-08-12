using Newtonsoft.Json;
using ViolaTricolor.Api.Contracts;
using ViolaTricolor.Enums;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Новость обновления списков друзей
    /// </summary>
    public class FriendsListUpdateNewContract
    {
        /// <summary>
        /// Кто
        /// </summary>
        [JsonProperty("who")]
        public VkUserContract Who { get; set; }

        /// <summary>
        /// Кого
        /// </summary>
        [JsonProperty("whom")]
        public VkUserContract Whom { get; set; }

        /// <summary>
        /// Отношение между вк пользователями
        /// </summary>
        [JsonProperty("relation_status")]
        public VkUserRelationsStatus VkUserRelationsStatus { get; set; }
    }
}
