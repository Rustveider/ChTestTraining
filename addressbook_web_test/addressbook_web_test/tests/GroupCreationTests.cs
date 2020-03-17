using System;
using System.Text;
using System.Text.RegularExpressions;
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
            app.Group.Create(group);
        }
    }
}
