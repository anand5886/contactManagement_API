using HRMS.Data.Models;
using HRMS.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Data.Contacts
{
    public interface IContactsRepository
    {
        Task<List<ContactEntity>> GetContacts();

        Task<string> SaveContact(TblContacts obj, string userId);
    }
}
