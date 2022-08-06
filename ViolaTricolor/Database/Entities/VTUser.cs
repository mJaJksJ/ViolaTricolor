using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViolaTricolor.Database.Entities
{
    /// <summary>
    /// Пользователь ViolaTricolor
    /// </summary>
    public class VTUser
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Вк аккаунт
        /// </summary>
        [ForeignKey("VkUserId")]
        public VkUser VkUser { get; set; }

        /// <summary>
        /// Id Вк аккаунта
        /// </summary>
        public long? VkUserId { get; set; }

        /// <summary>
        /// Vk пользователи на слежение за которыми подписанн VT пользователем
        /// </summary>
        public IEnumerable<VkUser> ObservableVkUsers { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VTUser>();

            entity.ToTable("VTUsers");
            entity.HasKey(t => t.Id);
            entity.Property(u => u.Login).IsRequired();
            entity.Property(u => u.Login).IsRequired();
            entity.HasIndex(u => u.Login).IsUnique();

            entity.HasMany(u => u.ObservableVkUsers)
                .WithMany(u => u.ObserverVTUsers);

            entity.HasOne(_ => _.VkUser);
        }
    }
}
