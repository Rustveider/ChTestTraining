using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            DataContact newData = new DataContact();
            newData.Firstname = "ModificationFirstnameTest";
            newData.Middlename = "ModificationMiddlenameTest";
            newData.Lastname = "ModificationLastnameTest";
            newData.Nickname = "ModificationNicknameTest";
            newData.Title = "ModificationTitleTest";
            newData.Company = "ModificationCompanyTest";
            newData.Address = "ModificationAddressTest";
            app.Contact.ContactCreationTest(1, newData);
        }
    }
}
