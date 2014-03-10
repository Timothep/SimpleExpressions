using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class EitherOfTests
    {
        [TestMethod]
        public void CharsOnlyEither()
        {
            var result = Siex.New()
                .EitherOf("a|e|i|o|u");

            Assert.AreEqual(@"(a|e|i|o|u)", result.Expression);

            Assert.IsTrue(result.IsMatch("a"));
            Assert.IsFalse(result.IsMatch("k"));
        }

        [TestMethod]
        public void CharsAndStringsEither()
        {
            var result = Siex.New()
                .EitherOf("ab|cd|e");

            Assert.AreEqual(@"(ab|cd|e)", result.Expression);

            Assert.IsTrue(result.IsMatch("cd"));
            Assert.IsFalse(result.IsMatch("bd"));
        }

        [TestMethod]
        public void StringsEither()
        {
            var result = Siex.New()
                .EitherOf("vowels|consons");

            Assert.AreEqual(@"(vowels|consons)", result.Expression);
        }
    }
}
