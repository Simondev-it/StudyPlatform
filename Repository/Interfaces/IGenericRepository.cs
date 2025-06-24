using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T >> GetAllAsync(Expression<Func<T , bool>>? predicate = null!, params Expression<Func<T , object>>[] includes);

     }
}
