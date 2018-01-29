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
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("Hello");
            group.Header = "world";
            group.Footer = "!";
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
           // Logout();
        }

    }
}
