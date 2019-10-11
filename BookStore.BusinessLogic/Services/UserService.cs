using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        
        public UserRepository UserRepository { get; set; }

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly RoleManager<Role> _roleManager;

        protected readonly TestAppContext _dataBase;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, TestAppContext dataBase)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataBase = dataBase;
            
            UserRepository = new UserRepository(_dataBase);
        }

        public async Task Registration(RegistrationModel registrationModel)
        {
            UserModel UserModel = new UserModel();
            UserModel.UserName = registrationModel.UserName;
            UserModel.FirstName = registrationModel.FirstName;
            UserModel.LastName = registrationModel.LastName;
            UserModel.Email = registrationModel.Email;
            
            IdentityResult identityResult = _userManager.CreateAsync(UserModel.MapToUserEntity(), registrationModel.Password).Result;
            if (identityResult.Succeeded)
            {
                User user = await _userManager.FindByNameAsync(UserModel.UserName);
                await _userManager.AddToRoleAsync(user, Enums.Roles.User.ToString());
            }
        }

        public async Task<string> GetEmailConfirmationToken(int id)
        {
            List<User> users = await UserRepository.ReadAll();
            User _user = users.FirstOrDefault(user => user.Id == id);

            var emailConfirmToken = _userManager.GenerateEmailConfirmationTokenAsync(_user);
            return await emailConfirmToken;
        }
        public async Task<string> GetEmailConfirmationToken(UserModel userModel)
        {
            List<User> users = await UserRepository.ReadAll();
            return await _userManager.GenerateEmailConfirmationTokenAsync(users.FirstOrDefault(user => user.Email == userModel.Email));
        }

        public async Task ConfirmEmail(UserModel userModel, string confirmToken)
        {
            User user =await _userManager.FindByEmailAsync(userModel.Email);

            await _userManager.ConfirmEmailAsync(userModel.MapToUserEntity(), confirmToken);
        }

        public async Task ConfirmEmail(string email, string confirmToken)
        {
            User user = await _userManager.FindByEmailAsync(email);

            await _userManager.ConfirmEmailAsync(user, confirmToken);
        }

        public async Task<UserModel> GetUserModelByEmaiil(string email)
        {
            User userEntity = await _userManager.FindByEmailAsync(email);

            UserModel userModel = new UserModel(userEntity);

            return  userModel;
        }
        public async Task<int> GetUserIdByUserName(string userName)
        {
            List<User> userEntityList = await UserRepository.ReadAll();

            User userEntity = userEntityList.FirstOrDefault(user=>user.UserName == userName);

            return userEntity.Id;
            
        }

        public async Task<string> GetIdByEmail(string email)
        {
            var userEntity =await _userManager.FindByEmailAsync(email);
            return userEntity.Id.ToString();
        }
        public async Task<UserModel> GetUserModelById(int id)
        {
            var userEntityList = await UserRepository.ReadAll();

            User userEntity = userEntityList.FirstOrDefault(user => user.Id == id);

            var userModel = new UserModel(userEntity);

            return userModel;
        }
        public async Task<SignInResult> Loggin(string id, string password)
        {
            User user =await _userManager.FindByIdAsync(id);
            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            return result;   
        }
    }
}
