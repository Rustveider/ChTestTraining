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
            app.Contact.DeleteContact(1);
        }
    }
}
