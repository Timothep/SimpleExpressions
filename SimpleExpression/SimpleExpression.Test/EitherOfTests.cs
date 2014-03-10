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
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("a|e|i|o|u")
                .Generate();

            Assert.AreEqual(@"(a|e|i|o|u)", result.Expression);

            Assert.IsTrue(result.IsMatch("a"));
            Assert.IsFalse(result.IsMatch("k"));
        }

        //[TestMethod]
        //public void NoPipeEither()
        //{
        //    dynamic se = new SimpleExpression();
        //    SimpleExpression result = se
        //        .EitherOf("aeiou")
        //        .Generate();

        //    Assert.AreEqual(@"[aeiou]", result.Expression);
        //}

        [TestMethod]
        public void CharsAndStringsEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("ab|cd|e")
                .Generate();

            Assert.AreEqual(@"(ab|cd|e)", result.Expression);

            Assert.IsTrue(result.IsMatch("cd"));
            Assert.IsFalse(result.IsMatch("bd"));
        }

        [TestMethod]
        public void StringsEither()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .EitherOf("vowels|consons")
                .Generate();

            Assert.AreEqual(@"(vowels|consons)", result.Expression);
        }
    }
}
