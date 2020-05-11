using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Mantis
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }
        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetAllFromUI(AccountData account)
        {
            manager.Navigator.GoToProjectPage();

            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Id = project.id,
                    Name = project.name,
                    Description = project.description
                });
            }
            return list;
        }

        public void ProjectElementVerification()
        {
            manager.Navigator.GoToProjectPage();
            if (!IsProjectExist())
            {
                ProjectData project = new ProjectData()
                {
                    Name = "test1"
                };
                AccountData account = new AccountData()
                            {
                                Name = "administrator",
                                Password = "password"
                            };
                Creation(account, project);
            }
        }

        public void Remove(int toBeRemoved)
        {
            manager.Navigator.Open_Homepage();
            manager.Navigator.GoToProjectPage();
            OpenProject(toBeRemoved);
            SubmintProjectRemove();
        }

        private void SubmintProjectRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;
        }

        private void OpenProject(int toBeRemoved)
        {
            driver.FindElement(By.CssSelector("td:nth-of-type(" + (toBeRemoved + 1) + ") > a")).Click();
        }

        public void Creation(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }

        private void SubmintProjectModification()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
        }

        private void FillProjectModification(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
        }

        private void InitProjectModification()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("td > a")).Count;
        }

        private bool IsProjectExist()
        {
            return IsElementPresent(By.CssSelector("td > a"));
        }




    }
}
