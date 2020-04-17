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

            DataContact newData = new DataContact("ModificationFirstnameTest113");
            newData.Lastname = null;


            List<DataContact> oldContacts = DataContact.GetAllContact();
            DataContact toBeRemoved = oldContacts[0];
            //DataContact oldData = oldContacts[0];

            app.Contact.ContactModification(newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContractCount());

            List<DataContact> newContacts = DataContact.GetAllContact();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            
            foreach (DataContact contact in newContacts)
            {
                if (contact.IdContacts == toBeRemoved.IdContacts)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}
