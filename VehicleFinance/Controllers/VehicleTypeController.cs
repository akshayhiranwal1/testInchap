using VehicleFinanceAPI.Api.Services.Generic;
using Microsoft.AspNetCore.Mvc;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : BaseController<VehicleTypeViewModel>
    {
        private readonly IGenericService<VehicleTypeViewModel> Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTypeController"/> class.
        /// </summary>
        /// <param name="service">The device service.</param>
        public VehicleTypeController(IGenericService<VehicleTypeViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}