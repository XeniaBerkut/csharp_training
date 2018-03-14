using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupModificationTest(GroupData newData)
        {            
            int i = 0;

            app.Groups.CreateIfNotPresent(i + 1);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[i];

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupModificationTest5(GroupData newData)
         {

             int i = 4;            

             app.Groups.CreateIfNotPresent(i + 1);

             List<GroupData> oldGroups = app.Groups.GetGroupList();
             GroupData oldData = oldGroups[i];

             app.Groups.Modify(i+1, newData);

             Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

             List<GroupData> newGroups = app.Groups.GetGroupList();
             oldGroups[i].Name = newData.Name;
             oldGroups.Sort();
             newGroups.Sort();
             Assert.AreEqual(oldGroups, newGroups);

             foreach (GroupData group in newGroups)
             {
                 if (group.Id == oldData.Id)
                 {
                     Assert.AreEqual(newData.Name, group.Name);
                 }
             }
         }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groupsmod.json"));
        }
    }
}
