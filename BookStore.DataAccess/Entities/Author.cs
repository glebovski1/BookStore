using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities
{
    public class Author : BaseEntity
    {

        public string Name { get; set; }

        public List<AuthorInBook> AuthorInBooks { get; set; }

        public Author()
        {
            AuthorInBooks = new List<AuthorInBook>(); 
        }

    }
}
