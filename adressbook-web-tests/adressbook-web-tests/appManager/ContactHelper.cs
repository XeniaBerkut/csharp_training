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
            if (!IsElementPresent(By.XPath("(//img[@alt='Edit'])[" + i+1 + "]")))
            {
                ContactData contact = new ContactData("Xenia", "Ivannikova")
                {
                    Address = "Южная д.9",
                    Email = "first@mail.ru",
                    Email2 = "second@mail.ru",
                    Email3 = "third@mail.ru",
                    HomePhone = "+7(916)555-66-77",
                    MobilePhone = "098-78-77",
                    WorkPhone = "75667 7777",
                    SecondaryHomePhone = "?"
                };

                Create(contact);
            }

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
            string secondaryHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");



            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                SecondaryHomePhone = secondaryHomePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
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
            if (contact.Address != null)
            {Type(By.Name("address"), contact.Address);}
            if (contact.Email != null)
            { Type(By.Name("email"), contact.Email); }
            if (contact.Email2 != null)
            { Type(By.Name("email2"), contact.Email2); }
            if (contact.Email3 != null)
            { Type(By.Name("email3"), contact.Email3); }
            if (contact.HomePhone != null)
            { Type(By.Name("home"), contact.HomePhone); }
            if (contact.MobilePhone != null)
            { Type(By.Name("mobile"), contact.MobilePhone); }
            if (contact.WorkPhone != null)
            { Type(By.Name("work"), contact.WorkPhone); }
            if (contact.SecondaryHomePhone != null)
            { Type(By.Name("phone2"), contact.SecondaryHomePhone); }
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
           // manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper CreateIfNotPresent(int index)
        {
           /* manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))

            {
                ContactData contact = new ContactData("Рекурсивный", "Был", "CreateIfNotPresent");
                Create(contact);
                CreateIfNotPresent(index);
            }*/

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

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
