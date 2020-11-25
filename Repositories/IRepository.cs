using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.WEB.Entities;


namespace WarehouseManagementSystem.WEB.Repositories

{
    public interface IRepository
    {
        Task SaveChangesAsync();
        Task<TEntity> SaveAsync<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        Task<TEntity> GetEntityById<TEntity>(Guid id) where TEntity : class, IEntity;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
