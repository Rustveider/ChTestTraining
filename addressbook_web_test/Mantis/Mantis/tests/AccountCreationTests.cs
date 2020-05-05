using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace Mantis
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }           
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser8",
                Password = "password",
                Email = "testuser8@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account); 
        }

        [TestFixtureTearDown]
            public void restoreConfig()
        {
            app.Ftp.RestorBackupFile("config_inc.php");
        }
    }
}
