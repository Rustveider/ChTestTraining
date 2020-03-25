using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            DataContact group = new DataContact("FirstnameTest4");

            group.Middlename = "MiddlenameTest";
            group.Lastname = "LastnameTest";
            group.Nickname = "NicknameTest";
            group.Title = "TitleTest";
            group.Company = "CompanyTest";
           // group.Address = "AddressTest";
            

            List<DataContact> oldContacts = app.Contact.GetContactList();

            app.Contact.ContactCreate(group);

            List<DataContact> newContacts = app.Contact.GetContactList();
            oldContacts.Add(group);

            Assert.AreEqual(oldContacts, newContacts);

            oldContacts.Sort();
            newContacts.Sort();
        }
        }
    }

