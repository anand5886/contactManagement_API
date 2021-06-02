using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblUserRole
    {
        public int UserRolePk { get; set; }
        public int UserIdPk { get; set; }
        public int RoleIdPk { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? MdifiedDatetime { get; set; }

        public virtual TblRole RoleIdPkNavigation { get; set; }
    }
}
