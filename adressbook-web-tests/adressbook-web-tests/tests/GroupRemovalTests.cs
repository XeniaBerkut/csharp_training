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
            app.Groups.Remove(1);            
        }

        [Test]
        public void GroupRemovalTest2()
        {
            app.Groups.Remove(2);
        }
    }
}
