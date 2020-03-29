using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //Проверка что есть группа для удаления
            app.Group.CheckeGroup(0);

            List<GroupData> oldGroups = app.Group.GetGroupList();
           
            app.Group.RemoveGroup(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newgroups = app.Group.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newgroups);

            foreach (GroupData group in newgroups)
            {
            Assert.AreNotEqual(group.Id, toBeRemoved.Id);
        }
    }
    }
}
