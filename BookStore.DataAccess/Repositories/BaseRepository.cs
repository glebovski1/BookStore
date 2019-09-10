using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {

        private readonly TestAppContext dataBase;

        public BaseRepository(TestAppContext _dataBase)
        {
            dataBase = _dataBase;
        }

        public async Task Create(TEntity item)
        {
            await dataBase.Set<TEntity>().AddAsync(item);
            await dataBase.SaveChangesAsync();

        }
                
        public async Task Delete(int id)
        {
            TEntity entity = await dataBase.Set<TEntity>().FindAsync(id);
            dataBase.Set<TEntity>().Remove(entity);
            await dataBase.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            dataBase.Dispose();
        }
        
        public async Task<List<TEntity>> ReadAll()
        {
           
            return await dataBase.Set<TEntity>().ToListAsync();
            
        }

        public async Task<TEntity> Read(int id)
        {
            return await dataBase.Set<TEntity>().FindAsync(id);
        }

        public async Task Save()
        {
            await dataBase.SaveChangesAsync(); 
        }

        public async Task Update(TEntity item)
        {
            dataBase.Set<TEntity>().Update(item);
            await dataBase.SaveChangesAsync();
        }
    }
}
