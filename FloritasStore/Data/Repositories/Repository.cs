using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FloritasStore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {        
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext _context)
        {
            _entities = _context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException();

            _entities.AddRange(entities);
        }
        
        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException();

            _entities.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
           
            _entities.Update(entity);
                      
        }        

        public IQueryable<T> FromSql(string sql, params object[] parameters) => _entities.FromSqlRaw(sql, parameters);
        
        public T Find(params object[] keyValues) => _entities.Find(keyValues);
        
        public async Task<T> FindAsync(params object[] keyValues) => await _entities.FindAsync(keyValues);

        public TResult GetFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).FirstOrDefault();
            }
            else
            {
                return query.Select(selector).FirstOrDefault();
            }
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }
        }

        
        public IQueryable<T> GetAll()
        {
            return _entities;
        }
        
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if(include != null)
            {
                query = include(query);
            }

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;

        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();

        }

        public bool Exists(Expression<Func<T, bool>> selector = null)
        {
            if (selector == null)
            {
                return _entities.Any();
            }
            else
            {
                return _entities.Any(selector);
            }
        }
        
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> selector = null)
        {
            if (selector == null)
            {
                return await _entities.AnyAsync();
            }
            else
            {
                return await _entities.AnyAsync(selector);
            }
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }
    }
}
