using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblModules
    {
        public TblModules()
        {
            TblFunctionality = new HashSet<TblFunctionality>();
        }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDesc { get; set; }
        public byte[] ModuleIcon { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

        public virtual ICollection<TblFunctionality> TblFunctionality { get; set; }
    }
}
