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
            int i = 1;
            app.Contacts.CreateIfNotPresent(i)
                        .Modify(i, contact);
        }



        [Test]
        public void ContactModificationTest10()
        {
            ContactData contact = new ContactData("Hello234", "Iam234", "Xenia234");
            int i = 10;
            app.Contacts.CreateIfNotPresent(i)
                        .Modify(i, contact);
        }
    }
}
