using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class OrderItems : BaseEntity
    {

        public int Amount { get; set; }

        public string Currency { get; set; }

        public int PrintingEditionId { get; set; }

        public int Count { get; set; }

    }
}
