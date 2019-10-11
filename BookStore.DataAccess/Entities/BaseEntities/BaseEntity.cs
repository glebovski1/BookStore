using BookStore.DataAccess.Entities.Interfaces;
using System;


namespace BookStore.DataAccess.Entities.BaseEntities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime DateTimeUtcNow { get; set; }

        public bool IsRemoved { get; set; }

        public BaseEntity()
        {
            DateTimeUtcNow = DateTime.UtcNow;
        }
    }
}
