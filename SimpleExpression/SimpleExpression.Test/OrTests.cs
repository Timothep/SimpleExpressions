using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class OrTests
    {
        [TestMethod]
        public void SimpleOr()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Text("http")
                .Or
                .Text("ftp")
                .Generate();

            Assert.AreEqual("(http|ftp)", result.Expression);
        }
    }
}
