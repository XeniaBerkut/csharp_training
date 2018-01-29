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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("Hello");
            group.Header = "world";
            group.Footer = "!";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }

    }
}
