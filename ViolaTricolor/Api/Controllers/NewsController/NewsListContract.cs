using System.Collections.Generic;

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
        public IEnumerable<INewsContract> NewsContract { get; set; }
    }
}
