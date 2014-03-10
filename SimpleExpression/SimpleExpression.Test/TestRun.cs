using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class TestRun
    {
        [TestMethod]
        public void TestRunner()
        {
            dynamic se = new SimpleExpression();
            Assert.AreEqual("","");
        }
    }
}
