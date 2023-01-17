

using EFCoreLayer.Common.Interfaces;
using EFCoreLayer.Entities;
using System;
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
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void AddRange<T>(List<T> entityList) where T : BaseEntity
        {
            try
            {
                await _dbContext.Set<T>().AddRangeAsync(entityList);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async void HardDelete<T>(T entity) where T : BaseEntity
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public async void HardDeleteById<T>(int id) where T : BaseEntity
        {
            try
            {
                var entity = await Find<T>(id);
                if (entity == null)
                {
                    throw new Exception("Entity couldn't found");
                }

                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void SoftDelete<T>(T entity) where T : BaseEntity
        {
            try
            {
                entity.UpdatedTime = DateTime.Now;
                entity.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void SoftDeleteById<T>(int id) where T : BaseEntity
        {
            try
            {
                var entity = await Find<T>(id);
                if (entity == null)
                {
                    throw new Exception("Entity couldn't found");
                }

                entity.UpdatedTime = DateTime.Now;
                entity.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async void Update<T>(T entity) where T : BaseEntity
        {
            try
            {
                entity.UpdatedTime = DateTime.Now;
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
