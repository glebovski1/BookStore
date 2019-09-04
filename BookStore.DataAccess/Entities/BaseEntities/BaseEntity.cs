using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationData { get; set; }

        public bool IsRemoved { get; set; }
    }
}
