using System;
using System.Collections.Generic;

namespace HRMS.Data.Models
{
    public partial class TblConfig
    {
        public int ConfigId { get; set; }
        public string ConfigType { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}
