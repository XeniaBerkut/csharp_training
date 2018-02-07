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
            app.Contacts.Remove(1);
        }

        [Test]
        public void ContactRemovalTest2()
        {
            app.Contacts.Remove(2);
        }

        [Test]
        public void ContactRemovalTest3()
        {
            app.Contacts.Remove(3);
        }

        [Test]
        public void ContactRemovalTest10()
        {
            app.Contacts.Remove(10);
        }

    }
}
