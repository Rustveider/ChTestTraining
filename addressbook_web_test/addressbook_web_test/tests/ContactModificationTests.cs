using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CheckeContact();

            DataContact newData = new DataContact("ModificationFirstnameTest111");
           // newData.Middlename = "ModificationMiddlenameTest";
            newData.Lastname = null;
            //newData.Nickname = "ModificationNicknameTest";
           // newData.Title = "ModificationTitleTest";
            //newData.Company = "ModificationCompanyTest";
           // newData.Address = "ModificationAddressTest";

            List<DataContact> oldContacts = app.Contact.GetContactList();
            DataContact oldData = oldContacts[0];

            app.Contact.ContactModification(newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContractCount());

            List<DataContact> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            
            foreach (DataContact contact in newContacts)
            {
                if (contact.IdContacts == oldData.IdContacts)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}
