using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.Phone.Testing;
using System.ComponentModel;

namespace TestApp2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Description("Check to see if AddIntegers works as desired")]
        public void AddIntegersTestShouldPass()
        {
            //Should Pass Since we are using Assert.IsTrue and 2+3=5
            var c = PivotApp1.MainPage.AddIntegers(2, 3);
            Assert.IsTrue(c == 5);
        }

        [TestMethod]
        [Description("Check to see if AddIntegers works as desired")]
        public void AddIntegersTestShouldPass2()
        {
            //Should Pass since we are using Assert.IsFalse and 2+3 does not equal 7
            var c = PivotApp1.MainPage.AddIntegers(2, 3);
            Assert.IsFalse(c == 7);
        }
        
    }
}
