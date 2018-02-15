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
            app.Groups.CreateIfNotPresent(i + 1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(i+1);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData tbr = oldGroups[i];
            oldGroups.RemoveAt(i);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, tbr.Id);
            }

        }

        [Test]
        public void GroupRemovalTest10()
        {
            int i = 9;       

            app.Groups.CreateIfNotPresent(i+1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(i+1);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());



            List<GroupData> newGroups = app.Groups.GetGroupList();

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldGroups[i].Id);
            }

            oldGroups.RemoveAt(i);
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
