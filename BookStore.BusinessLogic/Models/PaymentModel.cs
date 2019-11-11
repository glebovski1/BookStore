using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public string TransactionId { get; set;}

        public PaymentModel() { }

        public PaymentModel(Payment payment)
        {
            this.Id = payment.Id;
            this.TransactionId = payment.TransactionId;
        }
        public Payment PaymentModelMapToEntity()
        {
            Payment payment = new Payment();
            payment.TransactionId = this.TransactionId;
            return payment;
        }

    }
}
