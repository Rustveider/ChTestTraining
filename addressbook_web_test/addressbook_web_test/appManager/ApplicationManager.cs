﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ApplicationManager 
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
     
        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost:8080/addressbook/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;

            }
            return app.Value;
        }
        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        } 
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
    {
        get
        {
            return loginHelper;
        }
    }
    public NavigationHelper Navigator
    {
        get
        {
            return navigator;
        }
    }
    public GroupHelper Group
    {
        get
        {
            return groupHelper;
        }
    }
    public ContactHelper Contact
    {
        get
        {
            return contactHelper;
        }
    }
    }
    }

