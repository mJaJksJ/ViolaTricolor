using System.Globalization;
using Newtonsoft.Json;
using ViolaTricolor.Database.Entities;

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

        /// <summary>
        /// .ctor
        /// </summary>
        public VkUserContract(VkUser user)
        {
            Id = user.Id.ToString(CultureInfo.InvariantCulture);
            Name = user.Name;
            Surname = user.Surname;
        }
    }
}
