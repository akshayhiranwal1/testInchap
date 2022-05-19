using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Services.Interfaces
{
    public interface IVehicleFinanceRateMapping<T>
    {
        Task<IEnumerable<VehicleFinanceRateDetails>> GetByMake(string make);
    }
}
