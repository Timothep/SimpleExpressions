using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class TestRun
    {
        [Ignore]
        [TestMethod]
        public void TestRunner()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters
                .Except("a")
                .Generate();

            Assert.AreEqual("a|e|iy|uo", result.Expression);
        }
    }
}
