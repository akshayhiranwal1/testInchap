using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleFinanceAPI.Api.Data
{
    public interface IDbContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }
}