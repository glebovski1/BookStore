﻿using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Post")]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody]AuthorModel authorModel)
        {
            _authorService.AddAuthor(authorModel);
        }
    }
}