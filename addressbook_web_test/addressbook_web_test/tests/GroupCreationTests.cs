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
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            //чтение массива данных в файле и где он должен быть расположен
            string[] lines = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Groups.csv"));
            //string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
               string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            // List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize
            (new StreamReader(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Groups.xml")));
           /* //чтение массива данных в файле и где он должен быть расположен
            string[] lines = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"groups.xml"));
            //string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            } */
           // return groups;
        }
        //Метод для чтения Json формата файлов
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText
           (Path.Combine(TestContext.CurrentContext.WorkDirectory, @"Groups.json")));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData groups)
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Group.Create(groups);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
        /* [Test]
         public void EmptyGroupCreationTest()
         {
             GroupData group = new GroupData("");
             group.Header = "";
             group.Footer = "";

             List<GroupData> oldGroups = app.Group.GetGroupList();

             app.Group.Create(group);

             Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

             List<GroupData> newGroups = app.Group.GetGroupList();
             oldGroups.Add(group);
             oldGroups.Sort();
             newGroups.Sort();
             Assert.AreEqual(oldGroups, newGroups);

         }  */
        // Тест проверки на баг
        [Test]
          public void BadGroupCreationTest()
          {
              GroupData group = new GroupData("a 'a");
              group.Header = "HeaderTest";
              group.Footer = "FooterTest";

              List<GroupData> oldGroups = app.Group.GetGroupList();

              app.Group.Create(group);

              Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

              List<GroupData> newGroups = app.Group.GetGroupList();

              oldGroups.Add(group);
              oldGroups.Sort();
              newGroups.Sort();
              Assert.AreNotEqual(oldGroups, newGroups);
          }
        [Test]
        public void TestDBConnectivity()
        {
            foreach (DataContact contact in DataContact.GetAllContact())
            //foreach (DataContact contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact.Deprecated);
            }

            //DateTime start = DateTime.Now;
            //List<GroupData> fromUi =  app.Group.GetGroupList();
            //DateTime end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));

            //start = DateTime.Now;
            //List<GroupData> fromDB = GroupData.GetAll();
            //end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
