using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class MaybeTests
    {
        [TestMethod]
        public void SimpleMaybeTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Text("http")
                .Maybe("s")
                .Text("://")
                .Generate();

            Assert.AreEqual(@"http(s)?://", result.Expression);
        }
    }
}
