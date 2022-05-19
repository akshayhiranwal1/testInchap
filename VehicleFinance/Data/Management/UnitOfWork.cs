using System;
using System.Collections.Generic;
using VehicleFinanceAPI.Data;

namespace VehicleFinanceAPI.Api.Data.Management
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private VehicleFinanceContext dbContext;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(VehicleFinanceContext DbContext)
        {
            dbContext = DbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(dbContext);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}
