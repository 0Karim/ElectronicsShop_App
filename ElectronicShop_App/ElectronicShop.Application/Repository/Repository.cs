using ElectronicShop.Application.AppDbContext;
using ElectronicShop.Application.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicShop.Application.Repository
{
    public class Repository : IRepository
    {
        ApplicationDbContext _context;

        #region Ctor

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Private Methods

        private IQueryable<T> InsializeQuery<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        #endregion


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public int Count<T>() where T : class
        {
            return _context.Set<T>().Count();
        }

        public List<T> GetAll<T>(bool withTracking = false) where T : class
        {
            if (withTracking)
                return InsializeQuery<T>().ToList();
            else
                return InsializeQuery<T>().AsNoTracking().ToList();
        }

        public IQueryable<T> GetAllWhereQ<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery<T>(includes).Where(predicate);
        }

        public List<T> GetAllWithPaging<T>(int skip, int take, bool withTracking = false) where T : class
        {
            if (withTracking)
                return InsializeQuery<T>().Skip(skip).Take(take).ToList();
            else
                return InsializeQuery<T>().Skip(skip).Take(take).AsNoTracking().ToList();
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Attach(entity);
            _context.Update<T>(entity);
        }

        public bool SaveChangesAsync()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
