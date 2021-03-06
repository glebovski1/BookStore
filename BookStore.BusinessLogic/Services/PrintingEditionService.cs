﻿using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;

namespace BookStore.BusinessLogic.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IAuthorInBooksRepository _authorInBookRepository;

        private readonly IPrintingEditionRepository _printingEditionRepository;

        private readonly IAuthorRepository _authorRepository;

        public PrintingEditionService(
            IPrintingEditionRepository printingEditionRepository,
            IAuthorInBooksRepository authorInBooksRepository,
            IAuthorRepository authorRepository)
        
        {
            _authorInBookRepository = authorInBooksRepository;

            _printingEditionRepository = printingEditionRepository;

            _authorRepository = authorRepository;
        }
        
        public async Task AddPrintingEdition(PrintingEditionModel printingEditionModel)
        {

            var printingEditionEntity = printingEditionModel.PrintingEditionMapToEntity();
            await _printingEditionRepository.Create(printingEditionEntity);
            var authors = printingEditionModel.Authors;
            foreach (AuthorModel author in authors)
            {
                Author _author = await _authorRepository.FindByName(author.Name);
                if(_author == null)
                {
                    _author = new Author { Name = author.Name};
                }
                await _authorInBookRepository.Create(new AuthorInBook {PrintingEdition = printingEditionEntity, Author = _author });
            }
        }

        public async Task DeletePrintingEditionById(int id)
        {
            await _printingEditionRepository.Delete(id);
        }

        public async Task<int> GetPeintingEditionIdByName(string name)
        {
            var _printingEdition = await _printingEditionRepository.ReadAll();
            int id = _printingEdition.Where(printingEdition => printingEdition.Name == name).Select(printingEdition => printingEdition.Id).FirstOrDefault();
            return id;
        }


        public async Task<List<PrintingEditionModel>> GetPrintingEditionModels(int page)
        {
           
            List<PrintingEdition> printingEditionEntities = await _printingEditionRepository.ReadAll();

            List<int> printionEditionIdList = printingEditionEntities.Select(item => item.Id).ToList();

            Dictionary<int, List<AuthorInBook>> printingEditionAuthorInBooks = await _authorInBookRepository.GetByPrintingEditioIdList(printionEditionIdList);

            List<PrintingEditionModel> result = printingEditionEntities.Select(item => new PrintingEditionModel(item)
            {
                Authors = printingEditionAuthorInBooks.TryGetValue(item.Id, out List<AuthorInBook> authors) ?
                authors.Select(authorInBook => new AuthorModel(authorInBook.Author)).ToList()
                : null
            }).ToList();

            
            PageViewModel pageViewModel = new PageViewModel(
                result.Count(), page, 10
                );

            return result.Skip((page-1)* 10).Take(10).ToList();
        }

        public async Task<List<PrintingEditionModel>> GetPrintingEditionModelsFiltred(FilterModel filterModel)
        {
            

            List<PrintingEdition> printingEditionEntities = await _printingEditionRepository.ReadAll();

            List<int> printionEditionIdList = printingEditionEntities.Select(item => item.Id).ToList();

            Dictionary<int, List<AuthorInBook>> printingEditionAuthorInBooks = await _authorInBookRepository.GetByPrintingEditioIdList(printionEditionIdList);

            List<PrintingEditionModel> allPrintingEditionModels = printingEditionEntities.Select(item => new PrintingEditionModel(item)
            {
                Authors = printingEditionAuthorInBooks.TryGetValue(item.Id, out List<AuthorInBook> authors) ?
                authors.Select(authorInBook => new AuthorModel(authorInBook.Author)).ToList()
                : null
            }).ToList();


            List<PrintingEditionModel> result = allPrintingEditionModels;
            
            if(!string.IsNullOrWhiteSpace(filterModel.name))
            {
                result = result.Where(printingEdition => printingEdition.Name.StartsWith(filterModel.name)).ToList();
            }

            if(!string.IsNullOrWhiteSpace(filterModel.type))
            {
                result = result.Where(printingEdition => printingEdition.Type == filterModel.type).ToList();
            }

            if(!string.IsNullOrWhiteSpace(filterModel.author))
            {
                result = result.Where(printingEdition => printingEdition.Authors.Exists(author => author.Name == filterModel.author)).ToList();
            }

            if(!(filterModel.uperprice == 0))
            {
                result = result.Where(printingEdition => printingEdition.Price <= filterModel.uperprice).ToList();
            }

            if(!(filterModel.lowerprice == 0))
            {
                result = result.Where(printingEdition => printingEdition.Price >= filterModel.lowerprice).ToList();
            }

                PageViewModel pageViewModel = new PageViewModel(
                result.Count(), filterModel.pagenumber, 10
                );

            return result.Skip((filterModel.pagenumber - 1) * 10).Take(10).ToList();
        }
        public async Task<PrintingEditionModel> GetPrintingEditionModel(int id)
        {
            PrintingEditionModel printingEditionModel = new PrintingEditionModel(await _printingEditionRepository.Read(id));
            return printingEditionModel;
        }
    }
}
