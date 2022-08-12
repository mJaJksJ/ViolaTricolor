using Newtonsoft.Json;

namespace ViolaTricolor.Api.Contracts
{
    /// <summary>
    /// Контракт Вк пользователя
    /// </summary>
    public class VkUserContract
    {
        /// <summary>
        /// Имя
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonProperty("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Вк Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
