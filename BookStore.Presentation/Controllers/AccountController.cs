using BookStore.BusinessLogic.Autinfication.Interfaces;
using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<User> _userManager;
       
        private readonly UserService _userService;

        private readonly MailService _mailService;

        private readonly RoleManager<Role> _roleManager;
        public AccountController(UserService userService, MailService mailService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userService = userService;

            _mailService = mailService;

            _userManager = userManager;

            _roleManager = roleManager;
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

        // POST: api/Account
        [HttpPost("register")]
        public async Task Registratation([FromBody]RegistrationModel registrationModel)
        {

            await _userService.Registration(registrationModel);

            UserModel userModel = await _userService.GetUserModelByEmaiil(registrationModel.Email);



            string confirmToken = await _userService.GetEmailConfirmationToken(userModel);
                                                
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Request.Scheme}://{Request.Host}/api/account/confirmation/");
            stringBuilder.Append($"?email={HttpUtility.UrlEncode(registrationModel.Email)}");
            stringBuilder.Append($"&confirmToken={HttpUtility.UrlEncode(confirmToken)}");
            

            string callbackUrl = stringBuilder.ToString(); 

             await _mailService.SendEmailAsync(registrationModel.Email, "Confirmation", 
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

        }

        [HttpGet("confirmation")]
        public async Task EmailConfirmation(string email, string confirmToken)
        {
            await _userService.ConfirmEmail(email, confirmToken);
            
        }

        [HttpPost("Loggin")]
        [AllowAnonymous]
        public async Task<TokensResponseModel> Loggin(AuthenticationRequestModel authenticationRequestModel, [FromServices]IJwtSigningEncodingKey signingEncodingKey)
        {
            var result =await _userService.Loggin(await _userService.GetIdByEmail(authenticationRequestModel.Email), authenticationRequestModel.Password);

            var id = await _userService.GetIdByEmail(authenticationRequestModel.Email);

            User user = await _userManager.FindByIdAsync(id);
            var roles =  await _userManager.GetRolesAsync(user);
            string role = roles.FirstOrDefault();

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, authenticationRequestModel.Email),
                    new Claim(ClaimTypes.Role, role)
                    
                };

                var refreshClaims = new List<Claim>
                {
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(ClaimTypes.NameIdentifier, authenticationRequestModel.Email)
                };

                var token = new JwtSecurityToken(
                    issuer: "Test",
                    audience: "Bookstore",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: new SigningCredentials(signingEncodingKey.GetKey(), signingEncodingKey.SigningAlgorithm)
                    );

                var refreshToken = new JwtSecurityToken(
                    issuer: "Test",
                    audience: "Bookstore",
                    claims: refreshClaims,
                    expires: DateTime.Now.AddDays(60),
                    signingCredentials: new SigningCredentials(signingEncodingKey.GetKey(), signingEncodingKey.SigningAlgorithm)
                    );
                    

                string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                string refreshJwtToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);
                TokensResponseModel tokensResponseModel = new TokensResponseModel();
                tokensResponseModel.AccessToken = jwtToken;
                tokensResponseModel.RefreshToken = refreshJwtToken;
                tokensResponseModel.Role = role;
                await _userManager.SetAuthenticationTokenAsync(user, String.Empty, "RefreshToken", refreshJwtToken);
                return tokensResponseModel;
                    
            }

            return null;
        }

        [HttpPost("jwtrefresh")]
        public async Task<TokensResponseModel> RefreshToken([FromBody]RefreshTokenModel refreshTokenModel, [FromServices]IJwtSigningEncodingKey signingEncodingKey)
        {
            var user = await _userManager.FindByEmailAsync(refreshTokenModel.Email);
            var refreshTokeFromServer = await _userManager.GetAuthenticationTokenAsync(user, refreshTokenModel.LoginProvider, "RefreshToken");
            TokensResponseModel tokensResponseModel = new TokensResponseModel();
            if (refreshTokenModel.RefreshTokenFromClient == refreshTokeFromServer)
            {
                var roles = await _userManager.GetRolesAsync(user);
                string role = roles.FirstOrDefault();
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, refreshTokenModel.Email),
                    new Claim(ClaimTypes.Role, role)

                };

                var refreshClaims = new List<Claim>
                {
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(ClaimTypes.NameIdentifier, refreshTokenModel.Email)
                };

                var token = new JwtSecurityToken(
                    issuer: "Test",
                    audience: "Bookstore",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: new SigningCredentials(signingEncodingKey.GetKey(), signingEncodingKey.SigningAlgorithm)
                    );

                var refreshToken = new JwtSecurityToken(
                    issuer: "Test",
                    audience: "Bookstore",
                    claims: refreshClaims,
                    expires: DateTime.Now.AddDays(60),
                    signingCredentials: new SigningCredentials(signingEncodingKey.GetKey(), signingEncodingKey.SigningAlgorithm)
                    );


                string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                string refreshJwtToken = new JwtSecurityTokenHandler().WriteToken(refreshToken);
                
                tokensResponseModel.AccessToken = jwtToken;
                tokensResponseModel.RefreshToken = refreshJwtToken;
                await _userManager.SetAuthenticationTokenAsync(user, String.Empty, "RefreshToken", refreshJwtToken);

                return tokensResponseModel;
            }
            return null;
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
