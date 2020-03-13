using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            DataContact group = new DataContact();
            group.Firstname = "FirstnameTest4";
            group.Middlename = "MiddlenameTest";
            group.Lastname = "LastnameTest";
            group.Nickname = "NicknameTest";
            group.Title = "TitleTest";
            group.Company = "CompanyTest";
            group.Address = "AddressTest";
            app.Contact.ContactCreate(group);
        }
        }
    }

