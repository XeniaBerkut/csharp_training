using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Hello2", "Iam2", "Xenia2");
            int i = 0;
            app.Contacts.CreateIfNotPresent(i + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(i+1, contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[i].Firstname = contact.Firstname;
            oldContacts[i].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }



        [Test]
        public void ContactModificationTest10()
        {
            ContactData contact = new ContactData("Hello234", "Iam234", "Xenia234");
            int i = 9;
            app.Contacts.CreateIfNotPresent(i + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(i + 1, contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[i].Firstname = contact.Firstname;
            oldContacts[i].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
