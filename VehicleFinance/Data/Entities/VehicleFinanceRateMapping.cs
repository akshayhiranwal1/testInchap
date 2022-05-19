using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.Entities
{
    public partial class VehicleFinanceRateMapping
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

        public virtual FinanceRateRange FkFinanceRate { get; set; }
        public virtual Vehicle FkVehicle { get; set; }
    }
}
