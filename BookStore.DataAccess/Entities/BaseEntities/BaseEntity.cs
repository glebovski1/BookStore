using BookStore.DataAccess.Entities.Interfaces;
using System;


namespace BookStore.DataAccess.Entities.BaseEntities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationData { get; set; }

        public bool IsRemoved { get; set; }
    }
}
