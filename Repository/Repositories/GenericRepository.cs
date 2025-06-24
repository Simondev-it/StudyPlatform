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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly StudyPlatformContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StudyPlatformContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToListAsync();
        }

    }
}
