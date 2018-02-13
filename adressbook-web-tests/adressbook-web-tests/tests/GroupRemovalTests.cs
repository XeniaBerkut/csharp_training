using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest1()
        {
            int i = 1;

            app.Groups.CreateIfNotPresent(i)
                      .Remove(i);            
        }

        [Test]
        public void GroupRemovalTest10()
        {
            int i = 10;

            app.Groups.CreateIfNotPresent(i)
                      .Remove(i);
        }
    }
}
