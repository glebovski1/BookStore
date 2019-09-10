﻿using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    interface IOrderRepository : IBaseRepository<Order>
    {

        Task<Order> GetOrderWithOrderItems(int id);

    }
}
