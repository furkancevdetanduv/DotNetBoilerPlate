

using EFCoreLayer.Common.Interfaces;
using EFCoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreLayer.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ProjectDbContext _dbContext;

        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void AddRange<T>(List<T> entityList) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddRangeAsync(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteById<T>(int id) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(await Find<T>(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Find<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
