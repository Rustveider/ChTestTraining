using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis
{
    public class NavigatorHelper : HelperBase
    {
        public NavigatorHelper(ApplicationManager manager) : base(manager) { }
        public void Open_Homepage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.24.0/my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.24.0/my_view_page.php");
        }

        public void Open_Loginpage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.24.0/login_page.php");
        }

        public void GoToProjectPage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.24.0/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.24.0/manage_proj_page.php");
        }
    }
}
