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
            GroupData newData = new GroupData("aaa");
            newData.Header = "bbb";
            newData.Footer = "ccc";

            app.Groups.Modify(1, newData);



        }

        [Test]
        public void GroupModificationTest2()
        {
            GroupData newData = new GroupData("aaa");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);



        }

    }
}
