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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Title = GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Email = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                    Phone2 = GenerateRandomString(30),
                    Fax = GenerateRandomString(30),
                    Homepage = GenerateRandomString(30),
                    Bday = "1",
                    Bmonth = "January",
                    Byear = "2000",
                    Aday = "2",
                    Amonth = "February",
                    Ayear = "2001",
                    Address2 = GenerateRandomString(30),
                    Notes = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactInformationTest(ContactData contact)
        {
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

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactInformationDetailTest(ContactData contact)
        {
            int i = 0;
            app.Contacts.CreateIfNotPresentWithParam(i + 1, contact);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);

            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);

        }

        [Test]
        public void ContactInformationDetail2Test()
        {
            int i = 2;
            app.Contacts.CreateIfNotPresent(i + 1);
            ContactData fromDetailForm = app.Contacts.GetContactInformationFromDetailForm(i);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(i);
            string x = fromForm.AllInfo;

            
            Assert.AreEqual(fromForm.AllInfo, fromDetailForm.AllInfo);
        }
        /*
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
        }*/


    }
}
