using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        

        [Test]
        public void ContactCreationTest1()
        {
                    
            ContactData contact = new ContactData("Hello", "Iam", "Xenia");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactCreationTestFullForHomePage()
        {

            ContactData contact = new ContactData("Xenia", "Ivannikova")
            {
                Address = "Южная д.9",
                Email = "first@mail.ru",
                Email2 = "second@mail.ru",
                Email3 = "third@mail.ru",
                HomePhone = "+7(916)555-66-77",
                MobilePhone = "098-78-77",
                WorkPhone = "75667 7777",
                Phone2 = "?"
            };



            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactCreationTest2()
        {

            ContactData contact = new ContactData("Можно", "Ввести", "Кириллицу");
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
