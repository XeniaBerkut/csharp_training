using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {


        [Test]
        public void GroupRemovalTest1()
        {
            int i = 1;
            app.Groups.CreateIfNotPresent(i + 1);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData tbr = oldGroups[i];

            app.Groups.Remove(tbr);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();            
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

        [Test]
        public void GroupRemoveAll()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count != 0)
            {
                for (int i = 1; i <= oldGroups.Count; i++)
                {
                    app.Groups.Remove(1);
                }
            }
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(newGroups.Count, 0);

        }
    }
}
