using BookStore.DataAccess.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities
{
    public class OrderItems : BaseEntity
    {

        public int Amount { get; set; }

        public string Currency { get; set; }

        [ForeignKey("PrintingEdition")]
        public int PrintingEditionId { get; set; }

        public PrintingEdition PrintingEdition { get; set; }

        public int Count { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
