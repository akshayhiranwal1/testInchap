using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleFinanceAPI.Api.Services.Generic
{
    public interface IGenericService<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        T Create(T model);
        void Update(int id, T model);
        void Delete(int id);
        Task<IEnumerable<T>> GetByAny(int value);
    }
}
