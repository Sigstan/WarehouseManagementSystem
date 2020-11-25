using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.WEB.Data;
using WarehouseManagementSystem.WEB.Entities;
using WarehouseManagementSystem.WEB.Repositories;

namespace WarehouseManagementSystem.WEB.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetEntityById<TEntity>(Guid id) where TEntity : class, IEntity
        {
          return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> SaveAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
       
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
