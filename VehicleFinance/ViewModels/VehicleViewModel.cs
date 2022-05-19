using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.ViewModel
{
    public partial class VehicleViewModel
    {
        public VehicleViewModel()
        {
            VehicleFinanceRateMapping = new List<VehicleFinanceRateMappingViewModel>();
        }

        public int Id { get; set; }
        public int? FkVehicleTypeId { get; set; }
        public int? FkFinanceTypeId { get; set; }
        public int? FkMakeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual FinanceTypeViewModel FkFinanceType { get; set; }
        public virtual MakeViewModel FkMake { get; set; }
        public virtual VehicleTypeViewModel FkVehicleType { get; set; }
        public virtual ICollection<VehicleFinanceRateMappingViewModel> VehicleFinanceRateMapping { get; set; }
    }
}
