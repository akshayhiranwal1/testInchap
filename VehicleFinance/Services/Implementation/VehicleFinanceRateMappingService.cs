using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VehicleFinanceAPI.Api.Data.Management;
using VehicleFinanceAPI.Api.Repository;
using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Api.Services.Interfaces;
using VehicleFinanceAPI.Data.Entities;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Services
{
    public class VehicleFinanceRateMappingService<T> : IVehicleFinanceRateMapping<VehicleFinanceRateMappingViewModel>, IGenericService<VehicleFinanceRateMappingViewModel>
    {
        private IGenericRepository<VehicleFinanceRateMapping> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleFinanceRateMappingService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<VehicleFinanceRateMapping> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleFinanceRateMappingViewModel>> GetAll()
        {
            List<VehicleFinanceRateMappingViewModel> models = new List<VehicleFinanceRateMappingViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleFinanceRateMapping>, List<VehicleFinanceRateMappingViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<VehicleFinanceRateMappingViewModel>> GetAll(string include)
        {
            IList<VehicleFinanceRateMappingViewModel> models = new List<VehicleFinanceRateMappingViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleFinanceRateMapping>, List<VehicleFinanceRateMappingViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<VehicleFinanceRateMappingViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<VehicleFinanceRateMapping, VehicleFinanceRateMappingViewModel>(device);
            return model;
        }

        public VehicleFinanceRateMappingViewModel Create(VehicleFinanceRateMappingViewModel model)
        {
            var device = mapper.Map<VehicleFinanceRateMappingViewModel, VehicleFinanceRateMapping>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<VehicleFinanceRateMapping, VehicleFinanceRateMappingViewModel>(entity);
        }

        public void Update(int id, VehicleFinanceRateMappingViewModel model)
        {
            var device = mapper.Map<VehicleFinanceRateMappingViewModel, VehicleFinanceRateMapping>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<VehicleFinanceRateMappingViewModel>> GetByAny(int value)
        {
            IList<VehicleFinanceRateMappingViewModel> models = new List<VehicleFinanceRateMappingViewModel>();
            var model = await GenericRepository.FindBy(x => x.FkVehicleId == value);
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleFinanceRateMapping>, List<VehicleFinanceRateMappingViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<VehicleFinanceRateDetails>> GetByMake(string make)
        {
            IList<VehicleFinanceRateDetails> models = new List<VehicleFinanceRateDetails>();
            var model = await GenericRepository.GetAllWithInclude((x => x.FkVehicle.FkMake.Name.ToLower() == make.ToLower()),"FkVehicle", "FkFinanceRate","FkVehicle.FkFinanceType", "FkVehicle.FkVehicleType");

            if (model.Any())
            {
                var result = model.Select(i => new VehicleFinanceRateDetails() { 
                    Id = i.Id,
                    FkVehicleId = i.FkVehicleId,
                    FkFinanceRateId = i.FkFinanceRateId,
                    FinanceType = i.FkVehicle.FkFinanceType.Name,
                    RateValue = i.RateValue,
                    VehicleType = i.FkVehicle.FkVehicleType.Name,
                    FinanceRateType = i.FkFinanceRate.Name
                }).ToList();

                return result;
            }
            return models.AsEnumerable();
        }
    }
}

