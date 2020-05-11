using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestAccount
    {
        public static IEnumerable<ProjectData> RandomDataProvider()
        {
            List<ProjectData> project = new List<ProjectData>();
            for (int i = 0; i < 2; i++)
            {
                project.Add(new ProjectData()
                {
                    Name = GenerateRandonString(30),
                });
            }
            return project;
        }
        [Test, TestCaseSource("RandomDataProvider")]
        public void ProjectCreationTest()
        {

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };

            ProjectData project = new ProjectData()
            {
                Name = "test1",
                Description = "OneTest"
            };

            app.project.ProjectElementVerification();

            List<ProjectData> oldProjects = app.project.GetAllFromUI(account);
        
            app.project.Creation(account, project);

            Thread.Sleep(3000);
            Assert.AreEqual(oldProjects.Count + 1, app.project.GetProjectCount());

            List<ProjectData> newProjects = app.project.GetAllFromUI(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

