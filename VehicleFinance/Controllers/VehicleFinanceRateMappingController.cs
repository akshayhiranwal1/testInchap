using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Api.Services.Interfaces;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Controllers
{
   
    public class VehicleFinanceRateMappingController : BaseController<VehicleFinanceRateMappingViewModel>
    {
        private readonly IGenericService<VehicleFinanceRateMappingViewModel> Service;
        private readonly IVehicleFinanceRateMapping<VehicleFinanceRateMappingViewModel> VehicleService;
        public VehicleFinanceRateMappingController(IGenericService<VehicleFinanceRateMappingViewModel> service,
            IVehicleFinanceRateMapping<VehicleFinanceRateMappingViewModel> vehicleService) : base(service)
        {
            Service = service;
            VehicleService = vehicleService;
        }

        [HttpGet,Route("GetVehicleFinanceRateByMake/make")]
        public async Task<IActionResult> GetVehicleFinanceRateByMake(string make)
        {
            return new OkObjectResult(await VehicleService.GetByMake(make));
        }
    }
}