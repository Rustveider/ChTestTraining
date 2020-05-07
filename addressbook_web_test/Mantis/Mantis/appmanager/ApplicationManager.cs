using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Mantis
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        
        protected NavigatorHelper navigatorHelper;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;

        protected string baseUrl;

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseUrl = "http://localhost/mantisbt-2.24.0";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            navigatorHelper = new NavigatorHelper(this);
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectHelper(this);
            adminHelper = new AdminHelper(this, baseUrl);
        }

        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstasnce = new ApplicationManager();
                newInstasnce.driver.Url = newInstasnce.baseUrl + "/login_page.php";
                app.Value = newInstasnce;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }

        public FtpHelper Ftp { get; set; }

        public JamesHelper James { get; set; }

        public MailHelper Mail { get; set; }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }

        }
        public ProjectHelper project
        {
            get
            {
                return projectHelper;
            }
        }
        public NavigatorHelper Navigator
        {
            get
            {
                return navigatorHelper;
            }
        }
        public AdminHelper adminHelper { get; set; }
    }
}
