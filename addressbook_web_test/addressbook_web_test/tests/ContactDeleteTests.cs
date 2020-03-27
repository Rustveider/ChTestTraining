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
        public void ContactFeleteTest()
        {
            app.Contact.CheckeContact();

            List<DataContact> oldContacts = app.Contact.GetContactList();

            app.Contact.DeleteContact(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContractCount());

            List<DataContact> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
