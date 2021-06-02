using HRMS.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Business.Contacts
{
    public interface IContacts
    {
        Task<List<ContactEntity>> GetContacts();

        Task<string> SaveContact(object clsObj);
    }
}
