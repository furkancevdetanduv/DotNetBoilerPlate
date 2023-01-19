using DotNetBoilerPlate.EF.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetBoilerPlate.EF.Common.Interfaces
{
    public interface IGenericRepository
    {
        public Task<T> Add<T>(T entity) where T : BaseEntity;
        public Task AddRange<T>(List<T> entityList) where T : BaseEntity;
        public Task HardDelete<T>(T entity) where T : BaseEntity;
        public Task HardDeleteById<T>(int id) where T : BaseEntity;
        public Task SoftDelete<T>(T entity) where T : BaseEntity;
        public Task SoftDeleteById<T>(int id) where T : BaseEntity;
        public Task<T> Find<T>(int id) where T : BaseEntity;
        Task<T> FindByFilter<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        public Task Update<T>(T entity) where T : BaseEntity;
    }
}
