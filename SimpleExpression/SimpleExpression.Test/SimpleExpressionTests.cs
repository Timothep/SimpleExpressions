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
            
            var result = Siex.New()
                .Letters()
                .Numbers()
                ;

            Assert.AreEqual(@"[a-zA-Z]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsRegex()
        {
            
            var result = Siex.New()
                .Letters().Exactly(1)
                .Numbers().Exactly(1)
                ;

            Assert.AreEqual(@"[a-zA-Z]{1}[0-9]{1}", result.Expression);
        }

        [TestMethod]
        public void SimpleLettersAndMinusRegex()
        {
            
            var result = Siex.New()
                .Letters()
                .And("_")
                ;

            Assert.AreEqual(@"[a-zA-Z_]*", result.Expression);
        }

        [TestMethod]
        public void SimpleWildcardsWithWhitespacesRegex()
        {
            
            var result = Siex.New()
                .Letters()
                .And(" ")
                .Numbers()
                ;

            Assert.AreEqual(@"[a-zA-Z ]*[0-9]*", result.Expression);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            
            var result = Siex.New()
                .One("a")
                .Text("ei")
                .Text("ou")
                ;

            Assert.AreEqual(@"aeiou", result.Expression);
        }

        [TestMethod]
        public void CharacterDotRegex()
        {
            var result = Siex.New()
                .One(".");

            Assert.AreEqual(@"\.", result.Expression);
        }

        [TestMethod]
        public void CharactersRangeRegex()
        {
            
            var result = Siex.New()
                .OneOf("a|z")
                ;

            Assert.AreEqual(@"(a|z)", result.Expression);
        }

        [TestMethod]
        public void CharactersMixRegex()
        {
            
            var result = Siex.New()
                .One("a")
                .OneOf("i|j")
                .OneOf("x|y|z")
                ;

            Assert.AreEqual(@"a(i|j)(x|y|z)", result.Expression);

            Assert.IsTrue(result.IsMatch("aix"));
            Assert.IsTrue(result.IsMatch("ajy"));
            Assert.IsFalse(result.IsMatch("jy"));
            Assert.IsFalse(result.IsMatch("ij"));
            Assert.IsFalse(result.IsMatch("x-z"));
        }
    }
}

