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
            app.Contact.CheckContacts();
            app.Group.CheckGroup();

            GroupData group = GroupData.GetAll()[0];
            List<DataContact> oldList = group.GetContacts();
            DataContact contact = DataContact.GetAllContact().Except(oldList).First();

            for (int i = 0; i < oldList.Count(); i++)
            {
                if (oldList[i].IdContacts.Equals(contact.IdContacts))
                {
                    contact = new DataContact("test1");
                    app.Contact.ContactCreate(contact);
                    contact.IdContacts = app.Contact.GetContactId();
                }
            }

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
