using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public  string Decsription { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
               
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public List<OrderItems> OrderItems { get; set; }

    }
}
