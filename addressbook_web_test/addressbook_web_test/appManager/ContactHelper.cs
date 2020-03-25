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


        public ContactHelper ContactModification(DataContact newData)
        {
            manager.Navigator.GoToHome();
            SubmitContactMod();
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

        public ContactHelper SubmitContactMod()
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
            Type(By.Name("firstname"), group.Firstname);
            Type(By.Name("middlename"), group.Middlename);
            Type(By.Name("lastname"), group.Lastname);
            Type(By.Name("nickname"), group.Nickname);
            Type(By.Name("title"), group.Title);
            Type(By.Name("company"), group.Company);
            //Type(By.Name("address"), group.Address);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {// Проверить тест и с ним связанные
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
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

        public void CheckeContact()
        {
            if (!IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                DataContact group = new DataContact("Test", "LastnameTest");
                ContactCreate(group);
            }
        }
        public List<DataContact> GetContactList()
        {
            List<DataContact> groups = new List<DataContact>();

            manager.Navigator.GoToHome();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                var firstName = element.FindElements(By.XPath("./td"))[2].Text;
                var lastName = element.FindElements(By.XPath("./td"))[1].Text;

                DataContact contact = new DataContact(firstName, lastName);
                groups.Add(contact);
               // groups.Add(new DataContact(element.Text));
            }
            return groups;
        }
    }
}

