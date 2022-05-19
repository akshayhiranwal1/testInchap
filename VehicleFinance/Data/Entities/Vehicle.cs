using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.Entities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleFinanceRateMapping = new HashSet<VehicleFinanceRateMapping>();
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

        public virtual FinanceType FkFinanceType { get; set; }
        public virtual Make FkMake { get; set; }
        public virtual VehicleType FkVehicleType { get; set; }
        public virtual ICollection<VehicleFinanceRateMapping> VehicleFinanceRateMapping { get; set; }
    }
}
