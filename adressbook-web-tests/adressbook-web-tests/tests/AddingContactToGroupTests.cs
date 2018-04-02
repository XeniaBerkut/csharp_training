using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void ContactToGroupAddingTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            GroupData group = null;
            GroupData newGroup = new GroupData("Group");
            List<ContactData> allContacts = ContactData.GetAll();
            if (allContacts.Count == 0)
            {
                ContactData newContact = new ContactData("Contact", "C2");
                app.Contacts.Create(newContact);
                allContacts = ContactData.GetAll();
            }

            if (groups.Count < 1)
            {                
                app.Groups.Create(newGroup);
                groups = GroupData.GetAll();
                group = groups[0];
            }
            else
            {                
                for (int i = 0; i < groups.Count; i++)
                {
                    if (groups[i].GetContacts().Count < allContacts.Count)
                    {
                        group = groups[i];
                        i = groups.Count;
                    }
                    else
                    {
                        if (i == (groups.Count - 1) && group == null)
                        {                            
                            app.Groups.Create(newGroup);
                            i = 0;
                            groups = GroupData.GetAll();
                        }
                    }
                }                
            }           

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }

    }
}
