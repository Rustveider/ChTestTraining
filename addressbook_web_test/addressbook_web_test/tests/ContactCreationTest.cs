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
        public static IEnumerable<DataContact> RandomContactDataProvider()
        {
            List<DataContact> groups = new List<DataContact>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new DataContact(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(100),
                    Nickname = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(DataContact group)
        {
            //DataContact group = new DataContact("FirstnameTest1", "LastnameTest1");
           // group.Middlename = "MiddlenameTest";
           // group.Lastname = "LastnameTest";
           // group.Nickname = "NicknameTest";
            //group.Title = "TitleTest";
            //group.Company = "CompanyTest";
           // group.Address = "AddressTest";
            

            List<DataContact> oldContacts = app.Contact.GetContactList();

            app.Contact.ContactCreate(group);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContractCount());

            List<DataContact> newContacts = app.Contact.GetContactList();
            oldContacts.Add(group);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        /* [Test]
         public void EmptyContactsCreateTest()
         {
             DataContact contacts = new DataContact("");
             contacts.Middlename = "";
             contacts.Lastname = "";

             List<DataContact> oldContacts = app.Contact.GetContactList();

             app.Contact.ContactCreate(contacts);

             Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContractCount());

             List<DataContact> newContacts = app.Contact.GetContactList();
             oldContacts.Add(contacts);
             oldContacts.Sort();
             newContacts.Sort();
             Assert.AreEqual(oldContacts, newContacts);
         } */

    }
}

