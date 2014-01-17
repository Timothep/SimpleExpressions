﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = se
                .Letters
                .Numbers
                .Generate();

            Assert.AreEqual(@"[a-zA-Z]*[0-9]*", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void SimpleWildcardsRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letter
                .Number
                .Generate();

            Assert.AreEqual(@"[a-zA-Z][0-9]", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void SimpleWildcardsWithWhitespacesRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .LettersAndWhitespaces
                .Number
                .Generate();

            Assert.AreEqual(@"[a-zA-Z\s]*[0-9]", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Character('a')
                .ei
                .Sequence("ou")
                .Generate();

            Assert.AreEqual(@"aeiou", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void CharacterDotRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Character('.')
                .Generate();

            Assert.AreEqual(@"\.", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void CharactersRangeRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Characters("az")
                .Generate();

            Assert.AreEqual(@"[az]", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void CharactersMixRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Character('a')
                .Characters("ij")
                .Characters("x-z")
                .Generate();

            Assert.AreEqual(@"a[ij][x-z]", (result as SimpleExpression).Expression);
        }
    }
}
