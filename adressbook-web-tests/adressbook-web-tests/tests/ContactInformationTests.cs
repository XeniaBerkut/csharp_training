using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void TestContactInformation()
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
            int i = 5;


            app.Contacts.CreateIfNotPresentWithParam(i + 1, contact);
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationDetail()
        {
            ContactData contact = new ContactData("Ксения", "Иванникова")
            {
                Middlename = "Юрьевна",
                Nickname = "Xenia Berkut",
                Title = "NoName",
                Company = "ENGY",
                Address = "Южная д.9",
                HomePhone = "+7(916)555-66-77",
                MobilePhone = "098-78-77",
                WorkPhone = "75667 7777",
                Fax = "1234567890-0",
                Email = "first@mail.ru",
                Email2 = "second@mail.ru",
                Email3 = "third@mail.ru",
                Homepage = "all.in.one",
                Bday = "1",
                Bmonth = "January",
                Byear = "2000",
                Aday = "2",
                Amonth = "February",
                Ayear = "2001",
                Address2 = "Мирная, д.12",
                Phone2 = "9852",
                Notes = "Комментарий"
            };
            int i = 0;
            app.Contacts.CreateIfNotPresentWithParam(i + 1, contact);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);
            string x = fromForm.AllInfo;        
            

            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);

        }

        [Test]
        public void TestContactInformationDetail2()
        {
            int i = 2;
            app.Contacts.CreateIfNotPresent(i + 1);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);
            string x = fromForm.AllInfo;

            
            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);
        }

        [Test]
        public void TestContactInformationDetail3()
        {
            int i = 5;
            app.Contacts.CreateIfNotPresent(i + 1);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);
            string x = fromForm.AllInfo;


            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);
        }


        [Test]
        public void TestContactInformationDetail4()
        {
            int i = 6;
            app.Contacts.CreateIfNotPresent(i + 1);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);
            string x = fromForm.AllInfo;


            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);
        }


    }
}
