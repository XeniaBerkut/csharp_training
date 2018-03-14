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
            List<GroupData> groups = GroupData.GetAll();
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
                }
            }
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            app.Contacts.DeleteContactFromGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}
