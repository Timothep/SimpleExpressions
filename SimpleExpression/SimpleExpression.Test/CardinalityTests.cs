using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class CardinalityTests
    {
        [TestMethod]
        public void CardinalityMultipleBoundTests()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters
                .AtLeast(5)
                .Generate();

            Assert.AreEqual(@"[a-zA-Z]{5,}", result.Expression);
        }
    }
}