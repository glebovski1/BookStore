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
        public OrderModel()
        {

        }
        public string Decsription { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public DateTime Date { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public List<OrderItemsModel> OrderItemsModel { get; set; }

        public Order OrderMapToEntity()
        {
            Order order = new Order();
            order.Decsription = this.Decsription;
            order.UserId = this.UserId;
            if (!(this.User == null))
            {
                order.User = this.User.MapToUserEntity();
            }   
            order.DateTimeUtcNow = this.Date;
            order.PaymentId = this.PaymentId;
            order.Payment = this.Payment;
            return order;
        }

    }
}
