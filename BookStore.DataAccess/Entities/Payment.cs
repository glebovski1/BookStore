using BookStore.DataAccess.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public string TransactionId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
