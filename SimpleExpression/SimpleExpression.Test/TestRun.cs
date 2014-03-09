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
            SimpleExpression result = se
                .EitherOf("a|e|iy|uo")
                .Generate();

            Assert.AreEqual("a|e|iy|uo", result.Expression);
        }
    }
}
