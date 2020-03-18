﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public   class Close 
    {
        [OneTimeTearDown]
        public void CloseApplicationManager()
        {
            ApplicationManager.GetInstance().Dispose();
        }
    }
}
