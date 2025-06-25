using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : class where TKey : IEquatable<TKey>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(TKey id);

     }
}
