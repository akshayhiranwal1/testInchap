using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleController : BaseController<VehicleViewModel>
    {
        private readonly IGenericService<VehicleViewModel> Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="service">The device service.</param>
        public VehicleController(IGenericService<VehicleViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}