using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Models
{
    public class OrderItemsModel
    {
        public int Amount;

        public string Currency;

        public int PrintingEditionId;

        public int Count;

        public OrderItemsModel() { }

        public OrderItemsModel(OrderItems orderItems)
        {
            this.Amount = orderItems.Amount;
            this.Currency = orderItems.Currency;
            this.PrintingEditionId = orderItems.PrintingEditionId;
            this.Count = orderItems.Count;

        }

        public OrderItems OrderMapToEbtity()
        {
            OrderItems orderItems = new OrderItems();
            orderItems.Count = this.Count;
            orderItems.Amount = this.Amount;
            orderItems.Currency = this.Currency;
            orderItems.PrintingEditionId = this.PrintingEditionId;
            return  orderItems;
        }
    }
}
