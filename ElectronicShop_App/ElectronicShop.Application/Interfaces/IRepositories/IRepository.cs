using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElectronicShop.Application.Interfaces.IRepositories
{
    public interface IRepository
    {
        List<T> GetAll<T>(bool withTracking = false) where T : class;

        List<T> GetAllWithPaging<T>(int skip, int take, bool withTracking = false) where T : class;

        IQueryable<T> GetAllWhereQ<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        int Count<T>() where T : class;

        bool SaveChangesAsync();


        #region FirstorDefault

        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate, string[] includes) where T : class;

        #endregion
    }
}
