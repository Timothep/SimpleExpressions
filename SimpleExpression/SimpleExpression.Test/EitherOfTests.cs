using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [Ignore]
    [TestClass]
    public class EitherOfTests
    {
        [TestMethod]
        public void CharsOnlyEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("a|e|i|o|u")
                .Generate();

            Assert.AreEqual(@"a|e|i|o|u", result.Expression);
        }

        [TestMethod]
        public void NoPipeEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("aeiou")
                .Generate();

            Assert.AreEqual(@"[aeiou]", result.Expression);
        }

        [TestMethod]
        public void CharsAndStringsEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("ae|io|u")
                .Generate();

            Assert.AreEqual(@"ae|io|u", result.Expression);
        }

        [TestMethod]
        public void StringsEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("vowels|consons")
                .Generate();

            Assert.AreEqual(@"vowels|consons", result.Expression);
        }
    }
}
