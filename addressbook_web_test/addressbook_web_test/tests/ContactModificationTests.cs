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

            DataContact newData = new DataContact("ModificationFirstnameTest55", "ModificationLastnameTest");
            newData.Middlename = "ModificationMiddlenameTest";
           // newData.Lastname = "ModificationLastnameTest";
            newData.Nickname = "ModificationNicknameTest";
            newData.Title = "ModificationTitleTest";
            newData.Company = "ModificationCompanyTest";
           // newData.Address = "ModificationAddressTest";

            List<DataContact> oldContacts = app.Contact.GetContactList();

            app.Contact.ContactModification(newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContractCount());

            List<DataContact> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
