using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MakeController : BaseController<MakeViewModel>
    {
        private readonly IGenericService<MakeViewModel> Service;
        public MakeController(IGenericService<MakeViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}