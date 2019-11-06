using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Repositories
{
    public class OrderItemsRepository: BaseRepository<OrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepository(TestAppContext dataBase) : base(dataBase)
        {

        }
    }
}
