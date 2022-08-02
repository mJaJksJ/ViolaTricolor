using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ViolaTricolor.Database.Entities
{
    /// <summary>
    /// Пользователь ВК
    /// </summary>
    public class VkUser
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// VT пользователи подписанные на слежение за этим vk пользователем
        /// </summary>
        public IEnumerable<VTUser> VTUsers { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VkUser>();

            entity.ToTable("users");
            entity.HasKey(t => t.Id);

            entity.HasMany(t => t.VTUsers)
                .WithMany(t => t.VkUsers);
        }
    }
}
