using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;


namespace TestApp1.UnitTests
{
    [TestClass]
    class WP8UnitTest
    {
       
        [TestMethod]
        public void MainPageTest()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            Assert.IsNotNull(MPage);
        }

    }
}
