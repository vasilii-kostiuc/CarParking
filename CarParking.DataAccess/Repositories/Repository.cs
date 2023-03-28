using CarParking.DataAccess.Context;
using CarParking.DataAccess.Exceptions;
using CarParking.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected readonly DbSet<T> _dbSet;   

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity, bool persist = true)
        {
            _dbSet.Add(entity);
            if (persist)
            {
                await SaveChangesAsync();
            }
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, bool persist = true)
        {
            _dbSet.AddRange(entities);
            if (persist)
            {
                await SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(T entity, bool persist = true)
        {
            _dbSet.Remove(entity);
            if (persist)
            {
                await SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, bool persist = true)
        {
            var entity = new { Id = id};
            _dbContext.Entry(entity).State = EntityState.Deleted;
            if (persist)
            {
                await SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, bool persist = true)
        {
            _dbSet.RemoveRange(entities);
            if (persist)
            {
                await SaveChangesAsync();
            }
        }

        public async Task<T> FindAsync(int id) => await _dbSet.FindAsync(id);

        public async Task UpdateAsync(T entity, bool persist = true)
        {
            _dbSet.Update(entity);
            if (persist)
            {
                await SaveChangesAsync();
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, bool persist = true)
        {
            _dbSet.UpdateRange(entities);
            if (persist) {
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(CustomException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                //Should log and handle intelligently
                throw new CustomException("An error occurred updating the database", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync<T>();
        }
    }
}
