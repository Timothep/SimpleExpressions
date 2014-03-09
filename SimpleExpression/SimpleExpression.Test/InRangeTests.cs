using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
     
    [TestClass]
    public class InRangeTests
    {
          //SetBegin and InRange are creating a [()] structure that is not allowed by the C# Regex compiler
        [TestMethod]
        public void SimpleRangeTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .NumberInRange("1-5")
                .Generate();

            Assert.AreEqual(@"([1-4]|5)", result.Expression);
        }

        [TestMethod]
        public void SimpleLetterRangeTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .LetterInRange("a-d")
                .Generate();

            Assert.AreEqual(@"[a-d]", result.Expression);
        }

        [Ignore] //Cardinality in LetterInRange is not correct, LetterInRange should also be an ExtensibleNode
        [TestMethod]
        public void MultipleLettersRangeTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .LetterInRange("a-d").AtLeast(3).AtMost(10)
                .Generate();

            Assert.AreEqual(@"([a-d]{3,10})", result.Expression);
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .NumberInRange("1-9999")
                .One('/')
                .NumberInRange("1-12")
                .One('/')
                .NumberInRange("1-31")
                .Generate();

            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])",
                result.Expression);
        }
    }
}
