using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.BaseEntities;
using BookStore.DataAccess.Entities.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<BaseEntity> where TEntity : class, IBaseEntity
    {

        private readonly TestAppContext dataBase;

        public BaseRepository(TestAppContext _dataBase)
        {
            dataBase = _dataBase;
        }

        public async Task Create(TEntity item)
        {
            await dataBase.AddAsync<TEntity>(item);
            await dataBase.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            IBaseEntity baseEntity = dataBase.FindAsync(id);
            await dataBase.
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseEntity>> GetItemList()
        {
            return dataBase);
        }

        public Task<BaseEntity> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(BaseEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
