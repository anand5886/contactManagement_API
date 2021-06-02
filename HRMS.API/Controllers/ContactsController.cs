using HRMS.Business.Contacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRMS.API.Areas.Contacts.Controllers
{
    [Route("api/HRMS/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContacts _contact;
        public ContactsController(IContacts cls)
        {
            _contact = cls;
        }

        [Authorize]
        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact(object clsObj)
        {
            try
            {
                var result = await _contact.SaveContact(clsObj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var cls = await _contact.GetContacts();
                return Ok(cls);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
