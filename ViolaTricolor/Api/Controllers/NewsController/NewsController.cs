using Microsoft.AspNetCore.Mvc;
using ViolaTricolor.Api.Controllers.NewsController.Contracts;
using ViolaTricolor.Enums;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Контроллер взаимодействия с новостями
    /// </summary>
    public class NewsController : Controller
    {
        /// <summary>
        /// Получить новости
        /// </summary>
        [HttpGet("~/api/news")]
        [ProducesResponseType(typeof(NewsListContract), 200)]
        public IActionResult GetNews()
        {
            return Ok(new NewsListContract
            {
                News = new[] { new NewsContract { FriendsListUpdateNew = new FriendsListUpdateNewContract { VkUserRelationsStatus = VkUserRelationsStatus.Add } } }
            });
        }
    }
}
