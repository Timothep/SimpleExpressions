using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SimpleExpressionTests
    {
        /// http://regexpal.com/
        /// http://regexstorm.net/tester

        [TestMethod]
        public void MultiWildcardsRegex()
        {
            var result = S.Exp()
                .Letter()
                .Number();

            Assert.AreEqual(@"[a-zA-Z]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsRegex()
        {
            var result = S.Exp()
                .Letter().Exactly(1)
                .Number().Exactly(1);

            Assert.AreEqual(@"[a-zA-Z]{1}[0-9]{1}", result.Expression);
        }

        [TestMethod]
        public void SimpleLettersAndMinusRegex()
        {
            var result = S.Exp()
                .Letter()
                .And("_");

            Assert.AreEqual(@"[a-zA-Z_]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsWithWhitespacesRegex()
        {
            var result = S.Exp()
                .Letter()
                .And(" ")
                .Number();

            Assert.AreEqual(@"[a-zA-Z ]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            var result = S.Exp()
                .One('a')
                .Text("ei")
                .Text("ou");

            Assert.AreEqual(@"aeiou", result.Expression);
        }

        [TestMethod]
        public void CharacterDotRegex()
        {
            var result = S.Exp()
                .One('.');

            Assert.AreEqual(@"\.", result.Expression);
        }

        [TestMethod]
        public void CharactersRangeRegex()
        {
            var result = S.Exp()
                .OneOf("a|z");

            Assert.AreEqual(@"(a|z)", result.Expression);
        }

        [TestMethod]
        public void CharactersMixRegex()
        {
            var result = S.Exp()
                .One('a')
                .OneOf("i|j")
                .OneOf("x|y|z");

            Assert.AreEqual(@"a(i|j)(x|y|z)", result.Expression);

            Assert.IsTrue(result.IsMatch("aix"));
            Assert.IsTrue(result.IsMatch("ajy"));
            Assert.IsFalse(result.IsMatch("jy"));
            Assert.IsFalse(result.IsMatch("ij"));
            Assert.IsFalse(result.IsMatch("x-z"));
        }
    }
}

