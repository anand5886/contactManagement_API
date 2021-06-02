using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblRoleFunctionality
    {
        public int RoleFunctionalityId { get; set; }
        public int RoleIdPk { get; set; }
        public int FunctionalityIdPk { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

        public virtual TblFunctionality FunctionalityIdPkNavigation { get; set; }
        public virtual TblRole RoleIdPkNavigation { get; set; }
    }
}
