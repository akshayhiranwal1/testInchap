using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.ViewModel
{
    public partial class FinanceRateRangeViewModel
    {
        public FinanceRateRangeViewModel()
        {
            VehicleFinanceRateMapping = new List<VehicleFinanceRateMappingViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public List<VehicleFinanceRateMappingViewModel> VehicleFinanceRateMapping { get; set; }
    }
}
