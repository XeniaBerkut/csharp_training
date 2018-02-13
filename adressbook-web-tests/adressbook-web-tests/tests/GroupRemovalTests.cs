using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest1()
        {
            int i = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateIfNotPresent(i+1)
                      .Remove(i+1);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(i);
            Assert.AreEqual(oldGroups, newGroups);
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
