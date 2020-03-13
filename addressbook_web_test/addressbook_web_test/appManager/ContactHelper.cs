using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper ContactCreate(DataContact group)
        {
            manager.Navigator.GoToAddNew();
            FillContractForm(group);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }
        public ContactHelper DeleteContact(int v)
        {
            manager.Navigator.GoToHome();
            SelectContact(v);
            DeleteContact();
            AlertOk();
            manager.Navigator.GoToHome();
            return this;
        }

        public ContactHelper CModificationTests (DataContact newData)
        {
            manager.Navigator.GoToHome();
            ModificationContact();
            FillContractForm(newData);
            UpdateContactmodification();
            ReturnToContactPage();

            return this;
            
        } 

        public ContactHelper UpdateContactmodification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModificationContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper AlertOk()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper FillContractForm(DataContact group)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(group.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(group.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(group.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(group.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(group.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(group.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(group.Address);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper ReturnToContactPage()
        { 
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
}
    }

