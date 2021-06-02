using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblClient
    {
        public TblClient()
        {
            TblUserClient = new HashSet<TblUserClient>();
        }

        public int ClientId { get; set; }
        public string ClientAutoId { get; set; }
        public string ClientName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

        public virtual ICollection<TblUserClient> TblUserClient { get; set; }
    }
}
