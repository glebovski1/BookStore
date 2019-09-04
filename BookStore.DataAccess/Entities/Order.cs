using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Order : BaseEntity
    {

        public  string Decsription { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int PaymentId { get; set; }

    }
}
