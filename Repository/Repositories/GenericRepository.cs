 using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class where TKey : IEquatable<TKey>
    {

        private readonly StudyPlatformContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StudyPlatformContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;
            return query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
        

        public async ValueTask<T> CreateAsync(T t)
        {
            var result = await _dbSet.AddAsync(t);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}
