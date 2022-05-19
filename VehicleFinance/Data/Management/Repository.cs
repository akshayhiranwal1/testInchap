using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleFinanceAPI.Api.Data.Management
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly IDbContext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(IDbContext context)
        {
            this.context = context;

            dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public virtual EntityState Add(T entity)
        {
            return dbSet.Add(entity).State;
        }

        public T Get<TKey>(object id)
        {
            return dbSet.Find(nameof(id));
        }
        /// <inheritdoc />
        public T Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        /// <inheritdoc />
        public T Get(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        /// <inheritdoc />
        public EntityState Delete(T entity)
        {
            return dbSet.Remove(entity).State;
        }

        /// <inheritdoc />
        public virtual EntityState Update(T entity)
        {
            return dbSet.Update(entity).State;
        }

        public IQueryable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate, string include = null, string include2 = null, string include3 = null, string include4 = null, string include5 = null, string include6 = null, string include7 = null, string include8 = null, string include9 = null, string include10 = null, string include11 = null, string include12 = null, string include13 = null)
        {
            if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)) && (!string.IsNullOrEmpty(include9)) && (!string.IsNullOrEmpty(include10)) && (!string.IsNullOrEmpty(include11)) && (!string.IsNullOrEmpty(include12)) && (!string.IsNullOrEmpty(include13)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8).Include(include9).Include(include10).Include(include11).Include(include12).Include(include13);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)) && (!string.IsNullOrEmpty(include9)) && (!string.IsNullOrEmpty(include10)) && (!string.IsNullOrEmpty(include11)) && (!string.IsNullOrEmpty(include12)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8).Include(include9).Include(include10).Include(include11).Include(include12);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)) && (!string.IsNullOrEmpty(include9)) && (!string.IsNullOrEmpty(include10)) && (!string.IsNullOrEmpty(include11)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8).Include(include9).Include(include10).Include(include11);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)) && (!string.IsNullOrEmpty(include9)) && (!string.IsNullOrEmpty(include10)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8).Include(include9).Include(include10);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)) && (!string.IsNullOrEmpty(include9)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8).Include(include9);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)) && (!string.IsNullOrEmpty(include8)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7).Include(include8);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)) && (!string.IsNullOrEmpty(include7)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6).Include(include7);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)) && (!string.IsNullOrEmpty(include6)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5).Include(include6);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)) && (!string.IsNullOrEmpty(include5)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4).Include(include5);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)) && (!string.IsNullOrEmpty(include4)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3).Include(include4);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)) && (!string.IsNullOrEmpty(include3)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2).Include(include3);
            }
            else if ((!string.IsNullOrEmpty(include)) && (!string.IsNullOrEmpty(include2)))
            {
                return dbSet.Where(predicate).Include(include).Include(include2);
            }
            else if ((!string.IsNullOrEmpty(include)))
            {
                return dbSet.Where(predicate).Include(include);
            }

            return dbSet.Where(predicate).Include(include2);
        }
    }
}
