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
            int i = 1;

            app.Groups.CreateIfNotPresent(i)
                      .Modify(i, newData);



        }

        [Test]
        public void GroupModificationTest5()
        {
            GroupData newData = new GroupData("GroupModificationTest2");
            newData.Header = null;
            newData.Footer = null;
            int i = 5;

            app.Groups.CreateIfNotPresent(i)
                      .Modify(i, newData);
        }

    }
}
