using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
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


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData groups)
        {
            //удалить
         /*   GroupData group = new GroupData("AvtoTest");
            group.Header = "HeaderTest";
            group.Footer = "FooterTest";  */

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(groups);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
        [Test]
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

        }
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
    }
}
