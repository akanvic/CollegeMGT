using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Repo.Data.GenericRepository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private CollegeDbContext _collegeContext;



        public GenericRepository(CollegeDbContext collegeContext)
        {
            _collegeContext = collegeContext;
        }

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges) =>
            !trackChanges ? await Task.Run(() => _collegeContext.Set<T>().AsNoTracking()) : await Task.Run(() => _collegeContext.Set<T>());

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? await Task.Run(() => _collegeContext.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => _collegeContext.Set<T>().Where(expression));

        public Task<T> CreateAsync(T entity) => Task.Run(() => _collegeContext.Set<T>().Add(entity).Entity);


        public async Task<T> Get(int id)
        {
            return await _collegeContext.Set<T>().FindAsync(id);
        }
        public void Remove(int id)
        {
            T entity = _collegeContext.Set<T>().Find(id);
            Remove(entity);
        }
        public void Remove(T entity)
        {
            _collegeContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetMultiple(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string IncludeProperties = null)
        {
            IQueryable<T> query = _collegeContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (IncludeProperties != null)
            {
                foreach (var includeProp in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }
    }
}
