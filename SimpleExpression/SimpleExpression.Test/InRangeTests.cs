using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class InRangeTests
    {
        [TestMethod]
        public void SimpleRangeTest()
        {
            var result = S.Exp()
                .NumberInRange("1-5");

            Assert.AreEqual(@"([1-4]|5)", result.Expression);
        }

        [TestMethod]
        public void SimpleLetterRangeTest()
        {
            var result = S.Exp()
                .LetterInRange("a-d");

            Assert.AreEqual(@"[a-dA-D]", result.Expression);
        }

        [TestMethod]
        public void MultipleLettersRangeTest()
        {
            var result = S.Exp().LetterInRange("a-d").AtLeast(3).AtMost(10);

            Assert.AreEqual(@"[a-dA-D]{3,10}", result.Expression);

            Assert.IsTrue(result.IsMatch("aaa"));
            Assert.IsTrue(result.IsMatch("abd"));

            Assert.IsFalse(result.IsMatch("akakak"));
            Assert.IsFalse(result.IsMatch("fdg"));
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            var result = S.Exp()
                .NumberInRange("1-9999")
                .One("/")
                .NumberInRange("1-12")
                .One("/")
                .NumberInRange("1-31");

            //([1-9]|([1-9][0-9])|([1-9][0-9]{2})|((999[0-9])|(99[0-8][0-9])|(9[0-8][0-9]{2})|(0[0-8][0-9]{3})))

            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])",
                result.Expression);

            Assert.IsTrue(result.IsMatch("2014/03/10"));
            Assert.IsFalse(result.IsMatch("20142/033/130"));

        }
    }
}
