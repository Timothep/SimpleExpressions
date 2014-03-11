using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class LengthBoundsTest
    {
        [TestMethod]
        public void EmailRegex()
        {
            var result = S.Exp()
                .Alphanumeric().AtLeast(1)
                .One('@')
                .Alphanumeric().AtLeast(1)
                .One('.')
                .Alphanumeric().AtLeast(2).AtMost(5);

            Assert.AreEqual(@"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]{2,5}", result.Expression);
            Assert.IsTrue();
        }

        [TestMethod]
        public void SimpleDate()
        {
            var result = S.Exp()
                .Number().AtLeast(1).AtMost(4)
                .One('/')
                .Number().AtLeast(1).AtMost(2)
                .One('/')
                .Number().AtLeast(1).AtMost(2);

            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", result.Expression);
        }
    }
}
