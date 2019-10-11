using BookStore.DataAccess.Entities;

namespace BookStore.BusinessLogic.Models
{
    public class AuthorModel
    {
        public string Name { get; set; }

        public int Id { get; set; }
              
        public AuthorModel() { }
        
        internal AuthorModel(Author author)
        {
            this.Name = author.Name;

            this.Id = author.Id;
        }
              
        internal Author AuthorMapToEntity()
        {
            Author author = new Author();
            
            author.Name = this.Name;
                       
            return author;
        }
    }
}
