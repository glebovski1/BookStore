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

            //this.PaymentId = order.PaymentId;

            //this.PaymentModel = new PaymentModel(order.Payment);

        }
        public OrderModel()
        {

        }

        public int Id { get; set; }
        public string Decsription { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }

        public DateTime Date { get; set; }

        public int PaymentId { get; set; }

        public PaymentModel PaymentModel { get; set; }

        public string Email { get; set; }

        public string StripeToken { get; set; }
        
        public List<OrderItemsModel> OrderItemsModel { get; set; }

        public Order OrderMapToEntity()
        {
            Order order = new Order();
            order.Decsription = this.Decsription;
            order.UserId = this.UserId;
            
            
            return order;
        }

    }
}
