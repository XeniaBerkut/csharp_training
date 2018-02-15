using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            int i = 0;
            app.Contacts.CreateIfNotPresent(i+1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Remove(i+1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData tbr = oldContacts[i];
            oldContacts.RemoveAt(i);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData c in newContacts)
            {
                Assert.AreNotEqual(c.Id, tbr.Id);
            }
        }


        [Test]
        public void ContactRemovalTest10()
        {
            int i = 9;
            app.Contacts.CreateIfNotPresent(i+1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(i+1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData tbr = oldContacts[i];
            oldContacts.RemoveAt(i);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData c in newContacts)
            {
                Assert.AreNotEqual(c.Id, tbr.Id);
            }
        }

    }
}
