using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblContacts
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}
