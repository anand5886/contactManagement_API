using HRMS.Data.Models;
using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Data.Contacts
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly HRMSContext _hrmsContext;
        
        public ContactsRepository(HRMSContext _hrms)
        {           
            _hrmsContext = _hrms;
        }
        public async Task<List<ContactEntity>> GetContacts()
        {
            try
            {
                var contacts = from ct in _hrmsContext.TblContacts
                               select new ContactEntity
                               {
                                   LastName = ct.LastName,
                                   FirstName = ct.FirstName,
                                   ContactId = ct.ContactId,
                                   Email = ct.Email,
                                   Phone = ct.Phone,
                                   Status = (bool)ct.IsActive ? "Active" : "Inactive",
                               };
                return await Task.FromResult(contacts.ToList());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SaveContact(TblContacts clsObj, string userId)
        {
            try
            {
                string resultMsg = string.Empty;
                if (clsObj.ContactId == 0)
                {
                    clsObj.CreatedBy = userId;
                    _hrmsContext.TblContacts.Add(clsObj);
                    _hrmsContext.SaveChanges();
                    resultMsg = "Contact added successfully";
                }
                else
                {
                    var sb = _hrmsContext.TblContacts.FirstOrDefault(item => item.ContactId == clsObj.ContactId);
                    if (sb != null)
                    {
                        sb.FirstName = clsObj.FirstName;
                        sb.LastName = clsObj.LastName;
                        sb.IsActive = clsObj.IsActive;
                        sb.Email = clsObj.Email;
                        sb.Phone = clsObj.Phone;
                        sb.ModifiedBy = userId;
                        sb.ModifiedDatetime = DateTime.Now;
                        _hrmsContext.SaveChanges();
                        resultMsg = "Contact updated successfully";
                    }
                }
                return await Task.FromResult(resultMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
