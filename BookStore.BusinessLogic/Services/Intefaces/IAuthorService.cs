using BookStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Intefaces
{
    public interface IAuthorService
    {
        Task AddAuthor(AuthorModel authorModel);

        Task DeleteAuthorAsync(int id);

        Task<int> FindAuthorIdByName(string name);
        
    }
}
