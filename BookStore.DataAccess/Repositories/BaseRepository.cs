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

        protected readonly TestAppContext _dataBase;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TestAppContext dataBase)
        {
            _dataBase = dataBase;
            _dbSet = dataBase.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _dataBase.AddAsync(item);
            await _dataBase.SaveChangesAsync();
        }

       
                
        public async Task Delete(int id)
        {
            TEntity entity = await _dataBase.Set<TEntity>().FindAsync(id);
            _dataBase.Set<TEntity>().Remove(entity);
            await _dataBase.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _dataBase.Dispose();
        }
        
        public async Task<List<TEntity>> ReadAll()
        {
            return await _dbSet.ToListAsync();   
        }

        public async Task<TEntity> Read(int id)
        {
            return await _dataBase.Set<TEntity>().FindAsync(id);
        }

        public async Task Save()
        {
            await _dataBase.SaveChangesAsync(); 
        }

        public async Task Update(TEntity item)
        {
            _dataBase.Set<TEntity>().Update(item);
            await _dataBase.SaveChangesAsync();
        }
    }
}
