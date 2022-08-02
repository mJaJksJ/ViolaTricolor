using Microsoft.EntityFrameworkCore;
using ViolaTricolor.Database.Entities;

namespace ViolaTricolor.Database
{
    /// <inheritdoc cref="DbContext"/>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Пользователь ViolaTricolor
        /// </summary>
        public DbSet<VTUser> VTUsers { get; set; }

        /// <summary>
        /// Пользователь ВК
        /// </summary>
        public DbSet<VkUser> VkUsers { get; set; }

        /// <summary>
        /// Установить строку подключения
        /// </summary>
        public static string ConnectionString { private get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            VTUser.Setup(modelBuilder);
            VkUser.Setup(modelBuilder);
        }
    }
}