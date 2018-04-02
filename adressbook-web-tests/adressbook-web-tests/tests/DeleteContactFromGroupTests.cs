using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactFromGroupTests : AuthTestBase
    {

        [Test]
        public void ContactFromGroupDeleteTest()
        {
            GroupData group = null;
            ContactData contact = null;
            GroupData newGroup = new GroupData("Group");
            ContactData newContact = new ContactData("Contact", "C2");

            List<ContactData> allContacts = ContactData.GetAll();            
            if (allContacts.Count == 0)
            {                
                app.Contacts.Create(newContact);
            }
            allContacts = ContactData.GetAll();
            contact = allContacts[0];

            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {                
                app.Groups.Create(newGroup);
                groups = GroupData.GetAll();                
            }

            for (int k = 0; k < groups.Count;)
            {
                if (groups[k].GetContacts().Count > 0)
                {                    
                    group = groups[k];
                    k = groups.Count;
                }
                else
                {
                    k++;
                    if (k == (groups.Count) && group == null)
                    {
                        app.Contacts.AddContactToGroup(contact, groups[k-1]);
                        k = 0;
                        groups = GroupData.GetAll();
                    }
                }
            }

            List<ContactData> oldList = group.GetContacts();
            contact = group.GetContacts().First();

            app.Contacts.DeleteContactFromGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}
