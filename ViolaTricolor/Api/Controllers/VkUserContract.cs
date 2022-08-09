namespace ViolaTricolor.Api.Controllers
{
    /// <summary>
    /// Контракт Вк пользователя
    /// </summary>
    public class VkUserContract
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Вк Id
        /// </summary>
        public string Id { get; set; }
    }
}
