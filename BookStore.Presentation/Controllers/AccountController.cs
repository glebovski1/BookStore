using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/Acount
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Acount/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Acount
        [HttpPost]
        public async Task<IActionResult> Registratation([FromBody]RegistrationModel registrationModel)
        {
            if (registrationModel.IsPasswordConfirmed())
            {
               await _userService.Registration(registrationModel.UserName, 
                   registrationModel.FirstName, 
                   registrationModel.LastName, 
                   registrationModel.Emaill,
                   registrationModel.Password);

                return Ok(registrationModel);
            }
            return BadRequest();
            

        }

        // PUT: api/Acount/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
