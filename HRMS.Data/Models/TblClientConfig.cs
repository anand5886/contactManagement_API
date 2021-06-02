using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblClientConfig
    {
        public int ClientConfigId { get; set; }
        public string ClientKey { get; set; }
        public string ServerName { get; set; }
        public int? ServerPort { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
    }
}
