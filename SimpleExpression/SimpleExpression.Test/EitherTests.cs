using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void CharsOnlyEither()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Either("a|e|i|o|u")
                .Generate();

            Assert.AreEqual(@"a|e|i|o|u", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void NoPipeEither()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Either("aeiou")
                .Generate();

            Assert.AreEqual(@"[aeiou]", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void CharsAndStringsEither()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Either("ae|io|u")
                .Generate();

            Assert.AreEqual(@"ae|io|u", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void StringsEither()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Either("vowels|consons")
                .Generate();

            Assert.AreEqual(@"vowels|consons", (result as SimpleExpression).Expression);
        }
    }
}
