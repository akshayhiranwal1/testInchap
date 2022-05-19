using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.ViewModel
{
    public partial class VehicleFinanceRateMappingViewModel
    {
        public int Id { get; set; }
        public int? FkFinanceRateId { get; set; }
        public int? FkVehicleId { get; set; }
        public decimal? RateValue { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual FinanceRateRangeViewModel FkFinanceRate { get; set; }
        public virtual VehicleViewModel FkVehicle { get; set; }
    }

    public partial class VehicleFinanceRateDetails
    {
        public int Id { get; set; }
        public int? FkFinanceRateId { get; set; }
        public int? FkVehicleId { get; set; }
        public decimal? RateValue { get; set; }
        public string FinanceRateType { get; set; }
        public string FinanceType { get; set; }
        public string VehicleType { get; set; }
    }
}
