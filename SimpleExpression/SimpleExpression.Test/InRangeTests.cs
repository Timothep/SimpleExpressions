using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class InRangeTests
    {
        [Ignore] //Set and InRange are creating a [()] structure that is not allowed by the C# Regex compiler
        [TestMethod]
        public void SimpleRangeTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Numbers
                .InRange("1-5")
                .Generate();

            Assert.AreEqual(@"([1-4]|5)", result.Expression);
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Numbers.InRange("1-9999")
                .One('/')
                .Numbers.InRange("1-12")
                .One('/')
                .Numbers.InRange("1-31")
                .Generate();

            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])",
                result.Expression);
        }
    }
}
