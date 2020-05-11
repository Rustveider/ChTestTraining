using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantis
{
    public class ProjectRemoveTests : AuthTestAccount
    {
        [Test]
        public void ProjectRemoveTest()
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
            int toBeRemoved = 0;

            app.project.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.project.GetProjectCount());

            List<ProjectData> newProjects = app.project.GetAllFromUI(account);

            oldProjects.RemoveAt(toBeRemoved);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
