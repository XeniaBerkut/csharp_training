using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }


        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        protected void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        //private void SubmitContactCreation()
        //{
        //    driver.FindElement(By.Name("submit")).Click();
        //}

        protected void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            //driver.FindElement(By.Name("nickname")).Clear();
            //driver.FindElement(By.Name("nickname")).SendKeys("2");
            //driver.FindElement(By.Name("title")).Clear();
            //driver.FindElement(By.Name("title")).SendKeys("3");
            //driver.FindElement(By.Name("company")).Clear();
            //driver.FindElement(By.Name("company")).SendKeys("4");
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys("вафывафывафываф");
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys("дом");
            //driver.FindElement(By.Name("mobile")).Clear();
            //driver.FindElement(By.Name("mobile")).SendKeys("мобилка");
            //driver.FindElement(By.Name("work")).Clear();
            //driver.FindElement(By.Name("work")).SendKeys("работа");
            //driver.FindElement(By.Name("fax")).Clear();
            //driver.FindElement(By.Name("fax")).SendKeys("факс");
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys("мыло");
            //driver.FindElement(By.Name("email2")).Clear();
            //driver.FindElement(By.Name("email2")).SendKeys("мыло");
            //driver.FindElement(By.Name("email3")).Clear();
            //driver.FindElement(By.Name("email3")).SendKeys("мыло");
            //driver.FindElement(By.Name("homepage")).Clear();
            //driver.FindElement(By.Name("homepage")).SendKeys("дом");
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys("1233");
        }
    }
}
