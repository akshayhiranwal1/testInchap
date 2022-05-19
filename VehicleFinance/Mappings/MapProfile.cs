using AutoMapper.Configuration;
using VehicleFinanceAPI.Data.Entities;
using VehicleFinanceAPI.Data.ViewModel;

namespace VehicleFinanceAPI.Api.Mappings
{
    /// <summary>
    /// Contains objects mapping
    /// </summary>
    /// <seealso cref="MapperConfigurationExpression" />
    public class MapsProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsProfile"/> class
        /// </summary>
        public MapsProfile()
        {
            CreateMap<FinanceRateRangeViewModel, FinanceRateRange>().ReverseMap();
            CreateMap<FinanceTypeViewModel, FinanceType>().ReverseMap();
            CreateMap<VehicleViewModel, Vehicle>().ReverseMap();
            CreateMap<VehicleFinanceRateMappingViewModel, VehicleFinanceRateMapping>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleType>().ReverseMap();
            CreateMap<MakeViewModel, Make>().ReverseMap();
        }
    }
}
