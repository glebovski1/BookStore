using BookStore.DataAccess.Entities.BaseEntities;

namespace BookStore.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public int TransactionId { get; set; }
    }
}
