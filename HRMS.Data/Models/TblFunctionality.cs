using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblFunctionality
    {
        public TblFunctionality()
        {
            TblRoleFunctionality = new HashSet<TblRoleFunctionality>();
        }

        public int FunctionalityIdPk { get; set; }
        public int ModuleId { get; set; }
        public string FuncName { get; set; }
        public string FuncDesc { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

        public virtual TblModules Module { get; set; }
        public virtual ICollection<TblRoleFunctionality> TblRoleFunctionality { get; set; }
    }
}
