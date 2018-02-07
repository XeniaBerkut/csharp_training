using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Group");
            newData.Header = "Modification";
            newData.Footer = "Test";

            app.Groups.Modify(1, newData);



        }

        [Test]
        public void GroupModificationTest5()
        {
            GroupData newData = new GroupData("GroupModificationTest2");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(5, newData);



        }

    }
}
