using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using ViolaTricolor.Api.Controllers.NewsController.Contracts;
using ViolaTricolor.Api.Enums;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Контракт новости
    /// </summary>
    public class NewsContract
    {
        /// <summary>
        /// Типы новостей
        /// </summary>
        [NotNull]
        [JsonProperty("type")]
        public NewsType NewsType { get; set; }

        /// <summary>
        /// Новость обновления списков друзей
        /// </summary>
        [JsonProperty("friend_list_update")]
        public FriendsListUpdateNewContract FriendsListUpdateNew { get; set; }

        /// <summary>
        /// Дата и время фиксации
        /// </summary>
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }
    }
}
