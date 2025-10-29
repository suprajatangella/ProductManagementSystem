
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductManagementSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity ?? new T();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
