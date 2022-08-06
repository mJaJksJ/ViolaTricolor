using Microsoft.EntityFrameworkCore;

namespace ViolaTricolor.Database.Entities
{
    /// <summary>
    /// Друзья между пользователями
    /// </summary>
    public class VkFriend
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id первого вк пользователь
        /// </summary>
        public long FirstFriendId { get; set; }

        /// <summary>
        /// Первый вк пользователь
        /// </summary>
        public VkUser FirstFriend { get; set; }

        /// <summary>
        /// Id второго вк пользователь
        /// </summary>
        public long SecondFriendId { get; set; }

        /// <summary>
        /// Второй вк пользователь
        /// </summary>
        public VkUser SecondFriend { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<VkFriend>();

            entity.ToTable("VkFriends");
            entity.HasKey(t => t.Id);

            entity.HasOne(_ => _.FirstFriend);
            entity.HasOne(_ => _.SecondFriend);

            /*entity.HasOne(_ => _.FirstFriend)
                .WithMany(_ => _.Friends)
                .HasForeignKey(_ => _.FirstFriendId)
                .HasPrincipalKey(_ => _.Id)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(_ => _.SecondFriend)
                .WithMany(_ => _.Friends)
                .HasForeignKey(_ => _.SecondFriend)
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
