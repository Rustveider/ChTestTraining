using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToAddNew();
            DataContact group = new DataContact();
            group.Firstname = "FirstnameTest";
            group.Middlename = "MiddlenameTest";
            group.Lastname = "LastnameTest";
            group.Nickname = "NicknameTest";
            group.Title = "TitleTest";
            group.Company = "CompanyTest";
            group.Address = "AddressTest";
            app.Contact.FillContractForm(group);
            app.Contact.SubmitContactCreation();
            app.Stop(); // Почему то тест долго закрывается, хотя положительно пройден
        }
        }
    }

