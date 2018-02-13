﻿using System;
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
            int i = 0;

            app.Groups.CreateIfNotPresent(i + 1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(i+1, newData);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[i].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);



        }

        [Test]
        public void GroupModificationTest5()
        {
            GroupData newData = new GroupData("GroupModificationTest2");
            newData.Header = null;
            newData.Footer = null;
            int i = 4;            

            app.Groups.CreateIfNotPresent(i + 1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(i+1, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[i].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
