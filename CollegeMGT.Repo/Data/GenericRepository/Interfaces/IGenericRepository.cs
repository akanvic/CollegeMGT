using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Repo.Data.GenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> FindAllAsync(bool trackChanges);
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<T> CreateAsync(T entity);
        Task<T> Get(int id);
        void Remove(T entity);
        void Remove(int id);
        Task<IEnumerable<T>> GetMultiple(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string IncludeProperties = null);
    }
}
