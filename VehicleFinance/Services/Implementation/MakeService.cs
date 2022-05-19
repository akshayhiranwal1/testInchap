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
    public class MakeService<T> : IMake<MakeViewModel>, IGenericService<MakeViewModel>
    {
        private IGenericRepository<Make> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MakeService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<Make> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<MakeViewModel>> GetAll()
        {
            List<MakeViewModel> models = new List<MakeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<Make>, List<MakeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<MakeViewModel>> GetAll(string include)
        {
            IList<MakeViewModel> models = new List<MakeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<Make>, List<MakeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<MakeViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<Make, MakeViewModel>(device);
            return model;
        }

        public MakeViewModel Create(MakeViewModel model)
        {
            var device = mapper.Map<MakeViewModel, Make>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<Make, MakeViewModel>(entity);
        }

        public void Update(int id, MakeViewModel model)
        {
            var device = mapper.Map<MakeViewModel, Make>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<MakeViewModel>> GetByAny(int value)
        {
            IList<MakeViewModel> models = new List<MakeViewModel>();
            var model = await GenericRepository.FindBy(x => x.Id == value);
            if (model.Any())
                return mapper.Map<IEnumerable<Make>, List<MakeViewModel>>(model);
            return models.AsEnumerable();
        }
    }
}

