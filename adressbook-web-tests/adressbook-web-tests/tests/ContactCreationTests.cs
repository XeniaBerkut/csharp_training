using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        

        [Test]
        public void ContactCreationTest1()
        {
                    
            ContactData contact = new ContactData("Hello", "Iam", "Xenia");

            app.Contacts.Create(contact);

        }

        [Test]
        public void ContactCreationTest2()
        {

            ContactData contact = new ContactData("Можно", "Ввести", "Кириллицу");

            app.Contacts.Create(contact);

        }

    }
}
