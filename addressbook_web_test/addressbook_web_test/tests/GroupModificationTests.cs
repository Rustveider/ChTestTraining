using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Group.CheckeGroup(0);

            GroupData newData = new GroupData("AvtoModificationTest");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Group.GetGroupList();
           
            app.Group.Modify(1, newData);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

    }
}
