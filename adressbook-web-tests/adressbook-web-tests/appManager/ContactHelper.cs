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
            //manager.Navigator.GoToHomePage();
            SelectContactForEdit(v);
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
            //manager.Navigator.GoToHomePage();
            SelectContactForRemove(v);
            RemoveContact();
            CloseMessage();
            return this;
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
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();            
            //driver.FindElement(By.Id(" + index + ")).Click();
            return this;
        }

        public void SelectContactForRemove(int index)
        {
            manager.Navigator.GoToHomePage();
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                SelectContact(index);
            }
            else
            {
                ContactData contact = new ContactData("Тут", "Был", "SelectContactForRemove");
                Create(contact);
                SelectContactForRemove(index);
            }
            
            //driver.FindElement(By.Id(" + index + ")).Click();
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
            return this;
        }

        public ContactHelper SubmitModify()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public void SelectContactForEdit(int index)
        {
            manager.Navigator.GoToHomePage();
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                EditContact(index);
            }
            else
            {
                ContactData contact = new ContactData("Тут", "Был", "SelectContactForEdit");
                Create(contact);
                SelectContactForEdit(index);
            }
            
        }
    }
}
