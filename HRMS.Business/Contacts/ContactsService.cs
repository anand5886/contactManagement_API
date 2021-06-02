using HRMS.Data.Contacts;
using HRMS.Data.Models;
using HRMS.Entity.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Business.Contacts
{
    public class ContactsService : IContacts
    {
        private readonly IContactsRepository _repo;
        private readonly HttpContext httpContext;

        public ContactsService(IContactsRepository repo, IHttpContextAccessor httpContentAccessor)
        {
            _repo = repo;
            this.httpContext = httpContentAccessor.HttpContext;
        }

        public async Task<List<ContactEntity>> GetContacts()
        {
            return await _repo.GetContacts();
        }

        public async Task<string> SaveContact(object clsObj)
        {
            if (clsObj == null || string.IsNullOrEmpty(httpContext.Request.Headers["userId"]))
                return await Task.FromResult("Invalid Request");

            Dictionary<string, string> board = JsonConvert.DeserializeObject<Dictionary<string, string>>(clsObj.ToString());
            TblContacts cl = new TblContacts();
            cl.FirstName = board["firstName"].ToString();
            cl.LastName = board["lastName"].ToString();
            cl.Email = board["email"].ToString();
            cl.Phone = board["phone"].ToString();
            cl.IsActive = board["status"].ToString() == "Active" ? true : false;
            cl.ContactId = Convert.ToInt32(board["contactId"].ToString());
            return await _repo.SaveContact(cl, httpContext.Request.Headers["userId"].ToString());
        }
    }
}
