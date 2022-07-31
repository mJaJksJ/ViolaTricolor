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
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VTUser>();

            entity.ToTable("users");
            entity.HasKey(t => t.Id);
        }
    }
}
