using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Entity.Models
{
   public class UserRoleFunctionalityEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string FunctionalityName { get; set; }
        public string FunctionalityDescription { get; set; }
        public int FunctionalityID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
