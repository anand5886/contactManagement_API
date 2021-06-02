using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblRoleFunctionality = new HashSet<TblRoleFunctionality>();
            TblUserRole = new HashSet<TblUserRole>();
        }

        public int RoleIdPk { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? MdifiedDatetime { get; set; }

        public virtual ICollection<TblRoleFunctionality> TblRoleFunctionality { get; set; }
        public virtual ICollection<TblUserRole> TblUserRole { get; set; }
    }
}
