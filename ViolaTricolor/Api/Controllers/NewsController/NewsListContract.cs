using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Список контрактов новостей
    /// </summary>
    public class NewsListContract
    {
        /// <summary>
        /// Список контрактов новостей
        /// </summary>
        [JsonProperty("news")]
        public IEnumerable<NewsContract> News { get; set; }
    }
}
