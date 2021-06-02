using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblUser
    {
        public int UserIdPk { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public string MobileNumber { get; set; }
        public bool? IsConsentGiven { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public Guid UserPasswordSalt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}
