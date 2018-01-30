using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {

            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("Hello");
            group.Header = "world";
            group.Footer = "!";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            //app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            //app.Auth.Logout();
        }

    }
}
