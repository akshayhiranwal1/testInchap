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
    public class FinanceRateRangeService<T> : IFinanceRateRange<FinanceRateRangeViewModel>, IGenericService<FinanceRateRangeViewModel>
    {
        private IGenericRepository<FinanceRateRange> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FinanceRateRangeService(
            IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<FinanceRateRange> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        public async Task<IEnumerable<FinanceRateRangeViewModel>> GetAll()
        {
            List<FinanceRateRangeViewModel> models = new List<FinanceRateRangeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceRateRange>, List<FinanceRateRangeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<FinanceRateRangeViewModel>> GetAll(string include)
        {
            IList<FinanceRateRangeViewModel> models = new List<FinanceRateRangeViewModel>();
            var model = await GenericRepository.GetAll();
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceRateRange>, List<FinanceRateRangeViewModel>>(model);
            return models.AsEnumerable();
        }

        public async Task<FinanceRateRangeViewModel> GetById(int id)
        {
            var device = await GenericRepository.GetById(id);
            var model = mapper.Map<FinanceRateRange, FinanceRateRangeViewModel>(device);
            return model;
        }

        public FinanceRateRangeViewModel Create(FinanceRateRangeViewModel model)
        {
            var device = mapper.Map<FinanceRateRangeViewModel, FinanceRateRange>(model);
            var entity = GenericRepository.Create(device);
            return mapper.Map<FinanceRateRange, FinanceRateRangeViewModel>(entity);
        }

        public void Update(int id, FinanceRateRangeViewModel model)
        {
            var device = mapper.Map<FinanceRateRangeViewModel, FinanceRateRange>(model);
            GenericRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            var device = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Delete(device);
        }

        public async Task<IEnumerable<FinanceRateRangeViewModel>> GetByAny(int value)
        {
            IList<FinanceRateRangeViewModel> models = new List<FinanceRateRangeViewModel>();
            var model = await GenericRepository.FindBy(x => x.Id == value);
            if (model.Any())
                return mapper.Map<IEnumerable<FinanceRateRange>, List<FinanceRateRangeViewModel>>(model);
            return models.AsEnumerable();
        }
    }
}

