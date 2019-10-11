using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Repositories;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Intefaces
{
    public interface IUserService
    {
        UserRepository UserRepository { get; set; }

        Task Registration(RegistrationModel registrationModel);

    }
}
