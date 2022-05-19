using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FinanceTypeController : BaseController<FinanceTypeViewModel>
    {
        private readonly IGenericService<FinanceTypeViewModel> Service;
        public FinanceTypeController(IGenericService<FinanceTypeViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}