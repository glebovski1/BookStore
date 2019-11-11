using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BookStore.DataAccess.Repositories.Interfaces;

namespace BookStore.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task AddAuthor(AuthorModel authorModel)
        {
            await _authorRepository.Create(authorModel.AuthorMapToEntity());
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task<int> FindAuthorIdByName(string name)
        {
            var _authors = await _authorRepository.ReadAll();
            var id =  _authors.Where(author => author.Name == name).Select(author => author.Id).FirstOrDefault();
            return  id;
        }

        public async Task<string> GetAuthorNameById(int id)
        {
            var author = await _authorRepository.Read(id);

            return author.Name;
        }
        public async Task<List<AuthorModel>> GetAuthorModels()
        {
            var authorEnitieslList =await _authorRepository.ReadAll();
            var authorModelList = authorEnitieslList.Select(item => new AuthorModel(item)).ToList();
            return  authorModelList;
        }

    }
}
