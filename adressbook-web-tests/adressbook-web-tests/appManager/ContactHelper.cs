using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
    {
       
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public ContactHelper Modify(int v, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            EditContact(v);
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


            return new List<ContactData>(contactCache);
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

        public ContactHelper CreateIfNotPresent(int index)
        {
            manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))

            {
                ContactData contact = new ContactData("Тут", "Был", "CreateIfNotPresent");
                Create(contact);
                CreateIfNotPresent(index);
            }

            /*while (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                manager.Navigator.GoToHomePage();
                ContactData contact = new ContactData("Тут", "Был", "CreateIfNotPresent");
                Create(contact);
            }*/

                return this;
        }
    }
}
