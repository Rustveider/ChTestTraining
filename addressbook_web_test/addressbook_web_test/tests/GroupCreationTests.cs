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

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            Assert.AreEqual(oldGroups, newGroups);
            oldGroups.Sort();
            newGroups.Sort();
        }

        /* Тест проверки на баг
        [Test]
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a 'a");
            group.Header = "HeaderTest";
            group.Footer = "FooterTest";

            List<GroupData> oldGroups = app.Group.GetGroupList();

                app.Group.Create(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            Assert.AreEqual(oldGroups, newGroups);
            oldGroups.Sort();
            newGroups.Sort();
        } */
    }
}
