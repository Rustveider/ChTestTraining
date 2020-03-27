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
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("AvtoTest");
            group.Header = "HeaderTest";
            group.Footer = "FooterTest";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
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
            Assert.AreEqual(oldGroups, newGroups);
        } 
    }
}
