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

            app.Contacts.Modify(1, contact);
        }

        [Test]
        public void ContactModificationTest2()
        {
            ContactData contact = new ContactData("Hello23", "Iam23", "Xenia23");

            app.Contacts.Modify(2, contact);
        }

        [Test]
        public void ContactModificationTest10()
        {
            ContactData contact = new ContactData("Hello234", "Iam234", "Xenia234");

            app.Contacts.Modify(10, contact);
        }
    }
}
