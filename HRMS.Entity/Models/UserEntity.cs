using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Entity.Models
{
    public class UserEntity
    {
        public int USER_ID_PK { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientId { get; set; }
        public string RESPONSEMESSAGE { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
