using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class CardinalityTests
    {
        [TestMethod]
        public void CardinalityMultipleBoundTests()
        {
            var result = S.Exp()
                .Letter()
                .AtLeast(5);

            Assert.AreEqual(@"[a-zA-Z]{5,}", result.Expression);
        }
    }
}