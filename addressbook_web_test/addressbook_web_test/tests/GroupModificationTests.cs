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
            List<GroupData> oldgroups = app.Group.GetGroupList();

            app.Group.Modify(1, newData);
           
            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldgroups.Count, newGroups.Count);
        }

    }
}
