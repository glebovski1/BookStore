using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
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
        public UserModel UserModel { get; set; }
        public UserRepository UserRepository { get; set; }

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task UserRegistration(string userName, string firstName, string lastName, string emaill, string password)
        {
            UserModel = new UserModel();
            UserModel.UserName = userName;
            UserModel.FirstName = firstName;
            UserModel.LastName = lastName;
            UserModel.Email = emaill;
            await _userManager.CreateAsync(UserModel.MapToUserEntity(), password);
        }
            
        public async Task<int> GetUserIdByUserName(string userName)
        {
            List<User> userEntityList = await UserRepository.ReadAll();

            User userEntity = userEntityList.FirstOrDefault(user=>user.UserName == userName);

            return userEntity.Id;
            
        }

        public async Task<UserModel> GetUserModelById(int id)
        {
            var userEntityList = await UserRepository.ReadAll();

            User userEntity = userEntityList.FirstOrDefault(user => user.Id == id);

            var userModel = new UserModel(userEntity);

            return userModel;
        }

       
    }
}
