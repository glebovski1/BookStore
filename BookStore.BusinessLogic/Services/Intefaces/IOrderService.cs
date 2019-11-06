using BookStore.BusinessLogic.Models;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Intefaces
{
    public interface IOrderService
    {

        Task AddOrder(OrderModel orderModel);


        Task<List<OrderModel>> GetAllOrders();
    }
}
