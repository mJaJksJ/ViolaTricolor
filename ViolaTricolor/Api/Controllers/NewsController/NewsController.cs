using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViolaTricolor.Api.Contracts;
using ViolaTricolor.Api.Controllers.NewsController.Contracts;
using ViolaTricolor.Database;

namespace ViolaTricolor.Api.Controllers.NewsController
{
    /// <summary>
    /// Контроллер взаимодействия с новостями
    /// </summary>
    public class NewsController : Controller
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public NewsController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить новости
        /// </summary>
        [Authorize]
        [HttpGet("~/api/news")]
        [ProducesResponseType(typeof(NewsListContract), 200)]
        public IActionResult GetNews()
        {
            var contract = new NewsListContract
            {
                News = _context.FriendsJournals.Select(_ => new NewsContract
                {
                    NewsType = Enums.NewsType.FriendsListUpdate,
                    FriendsListUpdateNew = new FriendsListUpdateNewContract
                    {
                        Who = new VkUserContract(_.Who),
                        Whom = new VkUserContract(_.Whom),
                        VkUserRelationsStatus = _.RelationsStatus
                    },
                    DateTime = _.DateTime
                })
            };

            return Ok(contract);
        }
    }
}
