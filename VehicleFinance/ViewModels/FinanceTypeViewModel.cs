using System;
using System.Collections.Generic;

namespace VehicleFinanceAPI.Data.ViewModel
{
    public partial class FinanceTypeViewModel
    {
        public FinanceTypeViewModel()
        {
            Vehicle = new List<VehicleViewModel>();
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

        public List<VehicleViewModel> Vehicle { get; set; }
    }
}
