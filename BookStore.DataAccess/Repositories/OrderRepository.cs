using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(TestAppContext dataBase) : base(dataBase)
        {

        }

        
        //public async Task<Order> GetOrderWithOrderItems(int id)
        //{
        //    return await _dbSet.Include(order => order.OrderItems).FirstOrDefaultAsync(order => order.Id == id);
        //}
    }
}
