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
    public class FinanceTypeService<T> : IFinanceType<FinanceTypeViewModel>, IGenericService<FinanceTypeViewModel>
    {
        private IGenericRepository<FinanceType> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FinanceTypeService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<FinanceType> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<FinanceTypeViewModel>> GetAll()
        {
            List<FinanceTypeViewModel> models = new List<FinanceTypeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceType>, List<FinanceTypeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<FinanceTypeViewModel>> GetAll(string include)
        {
            IList<FinanceTypeViewModel> models = new List<FinanceTypeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceType>, List<FinanceTypeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<FinanceTypeViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<FinanceType, FinanceTypeViewModel>(device);
            return model;
        }

        public FinanceTypeViewModel Create(FinanceTypeViewModel model)
        {
            var device = mapper.Map<FinanceTypeViewModel, FinanceType>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<FinanceType, FinanceTypeViewModel>(entity);
        }

        public void Update(int id, FinanceTypeViewModel model)
        {
            var device = mapper.Map<FinanceTypeViewModel, FinanceType>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<FinanceTypeViewModel>> GetByAny(int value)
        {
            IList<FinanceTypeViewModel> models = new List<FinanceTypeViewModel>();
            var model = await GenericRepository.FindBy(x => x.Id == value);
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceType>, List<FinanceTypeViewModel>>(model);
            return models.AsEnumerable();
        }
    }
}

