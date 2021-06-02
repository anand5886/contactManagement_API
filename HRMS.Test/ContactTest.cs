using HRMS.API.Areas.Contacts.Controllers;
using HRMS.Business.Contacts;
using NUnit.Framework;

namespace HRMS.Test
{
    public class ContactTest
    {
        private readonly IContacts _contact;
        private ContactsController contactsController;
        public ContactTest(IContacts cls)
        {
            _contact = cls;
        }

        [SetUp]
        public void Setup()
        {
            contactsController = new ContactsController(_contact);
        }

        [Test]
        public void GetContacts()
        {
            var result = contactsController.GetContacts();
            Assert.That(result != null);
        }
    }
}