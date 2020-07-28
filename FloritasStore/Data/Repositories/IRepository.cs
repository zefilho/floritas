using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FloritasStore.Data.Repositories
{
    public interface IRepository<T> where T: class
    {        
        
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        IQueryable<T> FromSql(string sql, params object[] parameters);
        
        T Find(params object[] keyValues);

        Task<T> FindAsync(params object[] keyValues);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracking = true,
                                                  bool ignoreQueryFilters = false);
        
        Task<IList<T>> GetAllAsync();
        
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracking = true,
                                                  bool ignoreQueryFilters = false);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           bool disableTracking = true,
                                           bool ignoreQueryFilters = false);

        TResult GetFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                           Expression<Func<T, bool>> predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           bool disableTracking = true,
                                           bool ignoreQueryFilters = false);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           bool disableTracking = true,
                                           bool ignoreQueryFilters = false);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector,
                                           Expression<Func<T, bool>> predicate = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                           bool disableTracking = true,
                                           bool ignoreQueryFilters = false);
                
    }
}
