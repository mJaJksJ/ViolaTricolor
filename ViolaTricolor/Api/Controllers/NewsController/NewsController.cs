using Microsoft.AspNetCore.Mvc;

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
        /// <returns></returns>
        [HttpGet("~/api/news")]
        [ProducesResponseType(typeof(NewsListContract), 201)]
        public IActionResult GetNews()
        {
            return Ok(new NewsListContract
            {
                NewsContract = new[] { new FriendsListUpdateNew { VkUserRelationsStatus = Enums.VkUserRelationsStatus.Add } }
            });
        }
    }
}
