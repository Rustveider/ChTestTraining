using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

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
                groups.Add(new DataContact(GenerateRandomString(30)) //, GenerateRandomString(30) Вернуть обратно если тесты упадут
                {
                    Lastname = GenerateRandomString(100),
                    Nickname = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<DataContact> ContactDataFromCsvFile()
        {
            List<DataContact> groups = new List<DataContact>();
            //чтение массива данных в файле и где он должен быть расположен
            string[] lines = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Contact.csv"));
            //string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new DataContact(parts[0])
                {
                    Lastname = parts[1],
                    Address = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<DataContact> ContactDataFromXmlFile()
        {
            return (List<DataContact>)new XmlSerializer(typeof(List<DataContact>)).Deserialize
            (new StreamReader(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Contact.xml")));
        }

        public static IEnumerable<DataContact> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<DataContact>>(File.ReadAllText
           (Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Contact.json")));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(DataContact group)
        {
            //DataContact group = new DataContact("FirstnameTest1", "LastnameTest1");
           // group.Middlename = "MiddlenameTest";
           // group.Lastname = "LastnameTest";
           // group.Nickname = "NicknameTest";
            //group.Company = "CompanyTest";
           // group.Address = "AddressTest";
            
            List<DataContact> oldContacts = DataContact.GetAllContact();

            app.Contact.ContactCreate(group);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContractCount());

            List<DataContact> newContacts = DataContact.GetAllContact();
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
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<DataContact> fromUi = app.Contact.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<DataContact> fromDB = DataContact.GetAllContact();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}

