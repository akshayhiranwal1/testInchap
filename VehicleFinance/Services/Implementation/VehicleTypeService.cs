using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VehicleFinanceAPI.Api.Data.Management;
using VehicleFinanceAPI.Api.Repository;
using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.Entities;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Services
{
    public class VehicleTypeService<T> : IVehicleType<VehicleTypeViewModel>, IGenericService<VehicleTypeViewModel>
    {
        private IGenericRepository<VehicleType> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleTypeService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<VehicleType> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAll()
        {
            List<VehicleTypeViewModel> models = new List<VehicleTypeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleType>, List<VehicleTypeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAll(string include)
        {
            IList<VehicleTypeViewModel> models = new List<VehicleTypeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleType>, List<VehicleTypeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<VehicleTypeViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<VehicleType, VehicleTypeViewModel>(device);
            return model;
        }

        public VehicleTypeViewModel Create(VehicleTypeViewModel model)
        {
            var device = mapper.Map<VehicleTypeViewModel, VehicleType>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<VehicleType, VehicleTypeViewModel>(entity);
        }

        public void Update(int id, VehicleTypeViewModel model)
        {
            var device = mapper.Map<VehicleTypeViewModel, VehicleType>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetByAny(int value)
        {
            IList<VehicleTypeViewModel> models = new List<VehicleTypeViewModel>();
            var model = await GenericRepository.FindBy(x => x.Id == value);
            if (model.Any())
                return mapper.Map<IEnumerable<VehicleType>, List<VehicleTypeViewModel>>(model);
            return models.AsEnumerable();
        }
    }
}

