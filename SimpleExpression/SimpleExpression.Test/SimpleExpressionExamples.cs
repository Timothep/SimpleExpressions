﻿using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SimpleExpressionExamples
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

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z]*[0-9]*", pattern);
        }

        [TestMethod]
        public void SimpleWildcardsRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letter
                .Number
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z][0-9]", pattern);
        }

        [TestMethod]
        public void SimpleWildcardsWithWhitespacesRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .LettersAndWhitespaces
                .Number
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z\s]*[0-9]", pattern);
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

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"aeiou", pattern);
        }

        [TestMethod]
        public void CharacterDotRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Character('.')
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"\.", pattern);
        }

        [TestMethod]
        public void CharactersRangeRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Characters("az")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[az]", pattern);
        }
    }
}

