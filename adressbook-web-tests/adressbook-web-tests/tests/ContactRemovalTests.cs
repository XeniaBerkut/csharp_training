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
            int i = 1;
            app.Contacts.CreateIfNotPresent(i)
                        .Remove(i);
        }


        [Test]
        public void ContactRemovalTest10()
        {
            int i = 10;
            app.Contacts.CreateIfNotPresent(i)
                        .Remove(i);
        }

    }
}
