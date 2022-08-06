using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public long Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// VT аккаунт
        /// </summary>
        [ForeignKey("VtUserId")]
        public virtual VTUser VtUser { get; set; }

        /// <summary>
        /// Id VT аккаунта
        /// </summary>
        public int? VtUserId { get; set; }

        /// <summary>
        /// Подписанные на обновления vk пользователя vt пользователи
        /// </summary>
        public IEnumerable<VTUser> ObserverVTUsers { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VkUser>();

            entity.ToTable("VkUsers");
            entity.HasKey(t => t.Id);

            entity.HasMany(u => u.ObserverVTUsers)
                .WithMany(u => u.ObservableVkUsers);

            entity.HasOne(_ => _.VtUser);
        }
    }
}
