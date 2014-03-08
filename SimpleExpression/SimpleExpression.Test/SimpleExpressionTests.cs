using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

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
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters
                .Numbers
                .Generate();

            Assert.AreEqual(@"[a-zA-Z]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters.Exactly(1)
                .Numbers.Exactly(1)
                .Generate();

            Assert.AreEqual(@"[a-zA-Z]{1}[0-9]{1}", result.Expression);
        }

        [TestMethod]
        public void SimpleLettersAndMinusRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters
                .And("_")
                .Generate();

            Assert.AreEqual(@"[a-zA-Z_]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsWithWhitespacesRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Letters
                .And(" ")
                .Numbers
                .Generate();

            Assert.AreEqual(@"[a-zA-Z ]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .One('a')
                .Text("ei")
                .Text("ou")
                .Generate();

            Assert.AreEqual(@"aeiou", result.Expression);
        }

        [TestMethod]
        public void CharacterDotRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .One('.')
                .Generate();

            Assert.AreEqual(@"\.", result.Expression);
        }

        [TestMethod]
        public void CharactersRangeRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .OneOf("az")
                .Generate();

            Assert.AreEqual(@"[az]", result.Expression);
        }

        [TestMethod]
        public void CharactersMixRegex()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .One('a')
                .OneOf("ij")
                .OneOf("x-z")
                .Generate();

            Assert.AreEqual(@"a[ij][x-z]", result.Expression);
        }
    }
}

