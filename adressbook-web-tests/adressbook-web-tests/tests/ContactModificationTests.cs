using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(30),
                    Email = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                    Phone2 = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactModificationTest(ContactData contact)
        {            
            int i = 0;

            app.Contacts.CreateIfNotPresent(i + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldData = oldContacts[i];

            app.Contacts.Modify(i+1, contact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[i].Firstname = contact.Firstname;
            oldContacts[i].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData c in newContacts)
            {
                if (c.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname+contact.Lastname, c.Firstname + c.Lastname);
                }
            }
        }



       /* [Test]
        public void ContactModificationTest5()
        {
            ContactData contact = new ContactData("Hello234", "Iam234", "Xenia234");
            int i = 4;
            app.Contacts.CreateIfNotPresent(i + 1);
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldData = oldContacts[i];

            app.Contacts.Modify(i + 1, contact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[i].Firstname = contact.Firstname;
            oldContacts[i].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData c in newContacts)
            {
                if (c.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname + contact.Lastname, c.Firstname + c.Lastname);
                }
            }
        }*/
    }
}
