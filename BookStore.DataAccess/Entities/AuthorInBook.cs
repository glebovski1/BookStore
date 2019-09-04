using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class AuthorInBook : BaseEntity
    {

        public int AuthorId { get; set; }

        public int PrintingEditionId { get; set; }

        public DateTime Data { get; set; }

    }
}
