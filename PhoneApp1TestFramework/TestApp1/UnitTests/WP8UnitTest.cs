using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestWP8App.UnitTests
{
    [TestClass]
    public class WP8UnitTest
    {
        [TestMethod]
        [Description("Check to see if MainPage.xaml get instantiated")]
        public void MainPageTest()
        {
            //Should return true
            PhoneApp1TestFramework.MainPage MPage = new PhoneApp1TestFramework.MainPage();
            Assert.IsNotNull(MPage);
        }

        [TestMethod]
        [Description("Check to see if AddIntegers works as desired")]
        public void AddIntegersTestShouldPass()
        {
            //Should Pass Since we are using Assert.IsTrue and 2+3=5
            var c = PhoneApp1TestFramework.MainPage.AddIntegers(2, 3);
            Assert.IsTrue(c == 5);
        }

        [TestMethod]
        [Description("Check to see if AddIntegers works as desired")]
        public void AddIntegersTestShouldPass2()
        {
            //Should Pass since we are using Assert.IsFalse and 2+3 does not equal 7
            var c = PhoneApp1TestFramework.MainPage.AddIntegers(2, 3);
            Assert.IsFalse(c == 7);
        }
    }
}

