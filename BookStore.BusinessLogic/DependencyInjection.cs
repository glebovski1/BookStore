using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.BusinessLogic
{
    public static class DependencyInjection
    {

        public static void InjectDependency(IServiceCollection services)
        {
            
                       
            services.AddTransient<UserService>();
            services.AddTransient<MailService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<PrintingEditionService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorInBooksRepository, AuthorInBookRepository>();
        }

    }
}
