using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FinanceRateRangeController : BaseController<FinanceRateRangeViewModel>
    {
        private readonly IGenericService<FinanceRateRangeViewModel> Service;
        public FinanceRateRangeController(IGenericService<FinanceRateRangeViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}