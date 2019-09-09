using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetItemList();

        Task Create(T item);

        Task<T> Read(int id);

        Task Update(T item);

        Task Delete(int id);

        Task Save();
    }
}
