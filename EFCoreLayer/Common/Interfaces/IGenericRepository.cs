
using EFCoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreLayer.Common.Interfaces
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : BaseEntity;
        public void AddRange<T>(List<T> entityList) where T : BaseEntity;
        public void HardDelete<T>(T entity) where T : BaseEntity;
        public void HardDeleteById<T>(int id) where T : BaseEntity;
        public void SoftDelete<T>(T entity) where T : BaseEntity;
        public void SoftDeleteById<T>(int id) where T : BaseEntity;
        public Task<T> Find<T>(int id) where T : BaseEntity;
        public void Update<T>(T entity) where T : BaseEntity;
    }
}
