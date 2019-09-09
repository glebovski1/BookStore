using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string Currency { get; set; }

        public string Type { get; set; }

        public List<AuthorInBook> AuthorInBooks { get; set; }

        public PrintingEdition ()
        {
            AuthorInBooks = new List<AuthorInBook>();
        }

    }
}
