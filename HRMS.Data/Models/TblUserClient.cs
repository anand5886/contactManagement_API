using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblUserClient
    {
        public int UserClientPk { get; set; }
        public int UserIdPk { get; set; }
        public int ClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }

        public virtual TblClient Client { get; set; }
    }
}
