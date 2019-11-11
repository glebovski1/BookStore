using BookStore.DataAccess.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities
{
    public class AuthorInBook : BaseEntity
    {

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
               
        public Author Author { get; set; }

        [ForeignKey("PrintingEdition")]
        public int PrintingEditionId { get; set; }

        public PrintingEdition PrintingEdition { get; set; }
    }
}
