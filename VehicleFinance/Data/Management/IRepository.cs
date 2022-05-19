using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleFinanceAPI.Api.Data.Management
{
    /// <summary>
    /// Interface for generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">EF entity</typeparam>
    public interface IRepository<T>
    {
        T Get<TKey>(TKey id);
        T Get(params object[] keyValues);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        EntityState Add(T entity);
        EntityState Delete(T entity);
        EntityState Update(T entity);
        IQueryable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate, string include = null, string include2 = null, string include3 = null, string include4 = null, string include5 = null, string include6 = null, string include7 = null, string include8 = null, string include9 = null, string include10 = null, string include11 = null, string include12 = null, string include13 = null);
    }
}