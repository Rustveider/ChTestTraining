using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupsTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroups()
            {
            GroupData group = GroupData.GetAll()[0];
            List<DataContact> oldList = group.GetContacts();
            DataContact contact = DataContact.GetAllContact().Except(oldList).First();

            //action

            app.Contact.addContactToGroup(contact, group);

            List<DataContact> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void TestdeleteContactFromGroups()
        {
            GroupData group = GroupData.GetAll()[0];
            List<DataContact> oldList = group.GetContacts();
            DataContact contact = DataContact.GetAllContact().First();

            //action

            app.Contact.DeleteContactFromFroup(contact, group);

            List<DataContact> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreNotEqual(oldList, newList);
        }
    }
}
