using VehicleFinanceAPI.Api.Services.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace VehicleFinanceAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<TViewModel> : Controller where TViewModel : class
    {
        private IGenericService<TViewModel> GenericService { get; set; }

        public BaseController(IGenericService<TViewModel> genericService)
        {
            GenericService = genericService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await GenericService.GetAll());
        }

        [HttpGet("GetByAny/{value}")]
        public async Task<IActionResult> GetByAny([FromRoute][Required]int value)
        {
            return new OkObjectResult(await GenericService.GetByAny(value));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute][Required]int id)
        {
            return new ObjectResult(await GenericService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]TViewModel model)
        {
            var entity = GenericService.Create(model);
            return new OkObjectResult(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]TViewModel model)
        {
            GenericService.Update(id, model);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            GenericService.Delete(id);
            return new OkResult();
        }

    }
}