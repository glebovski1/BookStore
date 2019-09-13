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
    public class AcountController : ControllerBase
    {
        private readonly UserService _userService;

        public AcountController(UserService userService)
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
        public void RegistrateNewUser([FromBody]UserModel userModel)
        {
            //string userName;
            //string firstName;
            //string lastName;
            //string emaillAdress;
            //string password;
            //string confirmePassword;
               

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
