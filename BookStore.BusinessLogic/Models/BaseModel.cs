using BookStore.DataAccess.Entities.BaseEntities;
using System;

namespace BookStore.BusinessLogic.Models
{
    public class BaseModel
    {
        public BaseModel() { }

        public BaseModel(BaseEntity baseEntity)
        {
            this.Id = baseEntity.Id;
            this.DataCreated = baseEntity.CreationData;
            this.IsRemoved = baseEntity.IsRemoved;

        }
        public int Id { get; set; }

        public DateTime DataCreated { get; set; }

        public bool IsRemoved { get; set; }

        internal virtual BaseEntity MapToEntity()
        {
            BaseEntity baseEntity = new BaseEntity();
            baseEntity.Id = this.Id;
            baseEntity.CreationData = this.DataCreated;
            baseEntity.IsRemoved = this.IsRemoved;
            return baseEntity;
        }
    }
}
