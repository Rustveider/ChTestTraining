using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "NewTest"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestGroupRemove()
        {
            app.Groups.CheckeGroup();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Delete(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


    }
}
