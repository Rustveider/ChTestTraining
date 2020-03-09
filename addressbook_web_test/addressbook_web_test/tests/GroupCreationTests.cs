using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
    
        

        [Test]
        public void GroupCreationTest()
        {
           app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Group.InitGroupCreation();
            GroupData group = new GroupData("AvtoTest");
            group.Header = "HeaderTest";
            group.Footer = "FooterTest";
            app.Group.FillGroupForm(group);
            app.Group.SubmitGroupCreation();
            app.Group.ReturnToGroupsPage();
        }
    }
}
