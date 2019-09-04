using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Payment : BaseEntity
    {

        public int TransactionId { get; set; }
                
    }
}
