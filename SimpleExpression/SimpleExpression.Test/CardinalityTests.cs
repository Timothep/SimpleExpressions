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
            
            var result = Siex.New()
                .Letters()
                .AtLeast(5)
                ;

            Assert.AreEqual(@"[a-zA-Z]{5,}", result.Expression);
        }
    }
}