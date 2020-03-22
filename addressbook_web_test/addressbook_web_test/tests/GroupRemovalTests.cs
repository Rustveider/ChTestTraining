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

            List<GroupData> oldgroups = app.Group.GetGroupList();

            app.Group.RemoveGroup(0);

            List<GroupData> newgroups = app.Group.GetGroupList();

            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);
        }
    }
}
