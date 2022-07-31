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
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VTUser>();

            entity.ToTable("vtusers");
            entity.HasKey(t => t.Id);
            entity.Property(u => u.Login).IsRequired();
            entity.Property(u => u.Login).IsRequired();
            entity.HasIndex(u => u.Login).IsUnique();
        }
    }
}
