using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
         DataContact fromTable = app.Contact.GetContactInformationFromTable(0);
         DataContact fromForm = app.Contact.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
        [Test]
        public void TestContactOfDetailedInformation()
        {
            DataContact fromTable = app.Contact.GetContactInformationFromEditForm(0);
            DataContact fromForm = app.Contact.GetContactInformationFromDetailed(0);

            //проверка равенства данных страницы редактирования и свойств контакта
            Assert.AreEqual(fromTable.allInformations, fromForm.allInformations); 
        }
    }
}
