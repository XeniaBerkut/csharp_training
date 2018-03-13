using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
    {
       
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int i)
        {

            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }



        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Id);
            SubmitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public ContactHelper SubmitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }

        public ContactHelper SelectGroupToAdd(string groupId)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByValue(groupId);
            return this;
        }

        public ContactHelper ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            return this;
        }

        public ContactData GetContactInformationFromDetailForm(int i)
        {
            manager.Navigator.GoToHomePage();
            ShowContact(i + 1);
            string allInfo = driver.FindElement(By.Id("content")).Text;
            return new ContactData(allInfo);
        }

        public ContactHelper ShowContact(int index)
        {            
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + index + "]")).Click();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int i)
        {
            manager.Navigator.GoToHomePage();
            EditContact(i+1);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");




            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Homepage = homepage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes                
            };

        }

        public ContactHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            EditContact(v);
            FillContactForm(contact);
            SubmitModify();
            return this;
        }

        public ContactHelper Modify(ContactData oldData, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            EditContact(oldData.Id);
            FillContactForm(contact);
            SubmitModify();
            return this;
        }



        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();
            CloseMessage();
            return this;
        }

        public ContactHelper Remove(ContactData tbr)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(tbr.Id);
            RemoveContact();
            CloseMessage();
            return this;
        }



        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement element in elements)
                {
                    string a = element.FindElement(By.XPath(".//td[3]")).Text;
                    string b = element.FindElement(By.XPath(".//td[2]")).Text;
                    contactCache.Add(new ContactData(a, b) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

            }
            return new List<ContactData>(contactCache);
            //List<ContactData> contacts = new List<ContactData>();
            /*manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

            foreach (IWebElement element in elements)
            {
                string a = element.FindElement(By.XPath(".//td[3]")).Text;
                string b = element.FindElement(By.XPath(".//td[2]")).Text;
                //string a = element.FindElement(By.CssSelector("td:nth-of-type(3)")).Text;
                //string b = element.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
                contacts.Add(new ContactData(a, b));
            } */



        }

        public ContactHelper CloseMessage()
        {
            driver.SwitchTo().Alert().Accept();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();            
            return this;
        }

        public ContactHelper SelectContact(string contactId)
        {
            //driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + contactId + "'])")).Click();
            driver.FindElement(By.Id(contactId)).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            SelectByText(By.Name("bday"), contact.Bday);
            SelectByText(By.Name("bmonth"), contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            SelectByText(By.Name("aday"), contact.Aday);
            SelectByText(By.Name("amonth"), contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }



        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitModify()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {           
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper EditContact(string id)
        {
            driver.FindElement(By.XPath("(//a[@href='edit.php?id="+id+"'")).Click();
            return this;
        }

        public ContactHelper CreateIfNotPresent(int index)
        {
            manager.Navigator.GoToHomePage();
            int count = GetContactCount();
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                for (int i = index; i > count; count++)
                {
                    manager.Navigator.GoToHomePage();
                    ContactData contact = new ContactData("If", "For", "CreateIfNotPresent");
                    Create(contact);
                }
            }

            return this;
        }

        public ContactHelper CreateIfNotPresentWithParam(int index, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            int count = GetContactCount();
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                for (int i = index; i > count; count++)
                {
                    manager.Navigator.GoToHomePage();
                    Create(contact);
                }
            }
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
