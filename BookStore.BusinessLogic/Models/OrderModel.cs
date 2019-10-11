using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class OrderModel
    {
        public OrderModel(Order order)
        {
            this.Decsription = order.Decsription;

            this.UserId = order.UserId;

            this.User = new UserModel(order.User);

            this.Date = order.DateTimeUtcNow;

            this.PaymentId = order.PaymentId;

            this.Payment = order.Payment;

        }
        public string Decsription { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public DateTime Date { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public List<OrderItems> OrderItems { get; set; }

    }
}
