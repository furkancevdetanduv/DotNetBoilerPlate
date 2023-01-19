using DotNetBoilerPlate.EF.Common.Entities;
using DotNetBoilerPlate.EF.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetBoilerPlate.EF.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ProjectDbContext _dbContext;

        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddRange<T>(List<T> entityList) where T : BaseEntity
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

        public async Task HardDelete<T>(T entity) where T : BaseEntity
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

        public async Task HardDeleteById<T>(int id) where T : BaseEntity
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
        public async Task SoftDelete<T>(T entity) where T : BaseEntity
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

        public async Task SoftDeleteById<T>(int id) where T : BaseEntity
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

        public async Task<T> FindByFilter<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            try
            {
                return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update<T>(T entity) where T : BaseEntity
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
