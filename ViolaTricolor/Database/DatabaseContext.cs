using System.Linq;
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
        /// Журнал обновления друзей
        /// </summary>
        public DbSet<FriendsJournal> FriendsJournals { get; set; }

        /// <summary>
        /// Друзья между пользователями
        /// </summary>
        public DbSet<VkFriend> VkFriends { get; set; }

        /// <summary>
        /// Установить строку подключения
        /// </summary>
        public static string ConnectionString { private get; set; }

#pragma warning disable IDE0022
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
#pragma warning restore IDE0022

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            VTUser.Setup(modelBuilder);
            VkUser.Setup(modelBuilder);
            FriendsJournal.Setup(modelBuilder);
            VkFriend.Setup(modelBuilder);
        }

        /// <summary>
        /// Создать админ-пользователя
        /// </summary>
        public void CreateAdminUser()
        {
            if (!VTUsers.Any(_ => _.Login == "admin"))
            {
                VTUsers.Add(new VTUser
                {
                    Login = "admin",
                    Password = "admin",
                });

                SaveChanges();
            }
        }
    }
}
