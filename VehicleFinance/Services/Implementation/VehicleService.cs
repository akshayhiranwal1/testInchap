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
    public class VehicleService<T> : IVehicle<VehicleViewModel>, IGenericService<VehicleViewModel>
    {
        private IGenericRepository<Vehicle> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<Vehicle> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll()
        {
            List<VehicleViewModel> models = new List<VehicleViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<Vehicle>, List<VehicleViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll(string include)
        {
            IList<VehicleViewModel> models = new List<VehicleViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<Vehicle>, List<VehicleViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<VehicleViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<Vehicle, VehicleViewModel>(device);
            return model;
        }

        public VehicleViewModel Create(VehicleViewModel model)
        {
            var device = mapper.Map<VehicleViewModel, Vehicle>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<Vehicle, VehicleViewModel>(entity);
        }

        public void Update(int id, VehicleViewModel model)
        {
            var device = mapper.Map<VehicleViewModel, Vehicle>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<VehicleViewModel>> GetByAny(int value)
        {
            IList<VehicleViewModel> models = new List<VehicleViewModel>();
            var model = await GenericRepository.FindBy(x => x.FkVehicleTypeId == value);
            if (model.Any())
                return mapper.Map<IEnumerable<Vehicle>, List<VehicleViewModel>>(model);
            return models.AsEnumerable();
        }
    }
}

