using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace PhoneAppUnitTest2
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void MainPageTest()
        {
            //Should return true
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();

            Assert.IsNotNull(MPage);
        }

        [TestMethod]
        public void calctest()
        {
            // PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            int test = PivotApp1.MainPage.AddIntegers(2, 3);
            Assert.IsTrue(5 == test);
        }

    }
}
