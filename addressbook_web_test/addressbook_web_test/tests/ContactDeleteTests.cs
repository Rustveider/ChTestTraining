using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDeleteTests : AuthTestBase
    {
        [Test]
        public void ContactDeleteTest()
        {
            app.Contact.CheckeContact();

            List<DataContact> oldContacts = DataContact.GetAllContact();
            DataContact toBeRemoved = oldContacts[0];

            app.Contact.DeleteContactBD(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContractCount());

            List<DataContact> newContacts = DataContact.GetAllContact();
           
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (DataContact contacts in newContacts)
           {
                Assert.AreNotEqual(contacts.IdContacts, toBeRemoved.IdContacts);
           }
        }
    }
}
