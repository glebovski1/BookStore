using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("testvalue")]
        public string GetTestValue([FromBody]AuthenticationRequestModel authenticationRequestModel)
        {
            
            return "Authorization is working";
           
            
        }
    }
   
}