using System;
using Microsoft.EntityFrameworkCore;
using ViolaTricolor.Enums;

namespace ViolaTricolor.Database.Entities
{
    /// <summary>
    /// Журнал обновления друзей
    /// </summary>
    public class FriendsJournal
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Кто сделал
        /// </summary>
        public VkUser Who { get; set; }

        /// <summary>
        /// Who's id
        /// </summary>
        public long WhoId { get; set; }

        /// <summary>
        /// С кем
        /// </summary>
        public VkUser Whom { get; set; }

        /// <summary>
        /// Whom's id
        /// </summary>
        public long WhomId { get; set; }

        /// <summary>
        /// Дата и время фиксации
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Изменение отношения
        /// </summary>
        public VkUserRelationsStatus RelationsStatus { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<FriendsJournal>();

            entity.ToTable("FriendsJournal");
            entity.HasKey(t => t.Id);

            entity.HasOne(_ => _.Who);
            entity.HasOne(_ => _.Whom);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Who.Id} {RelationsStatus} {Whom.Id}";
        }
    }
}
