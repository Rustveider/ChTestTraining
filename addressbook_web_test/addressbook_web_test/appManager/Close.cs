using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public   class Close : TestBase
    {
        [OneTimeTearDown]
        public void CloseApplicationManager()
        {
            app.Dispose();
        }
    }
}
