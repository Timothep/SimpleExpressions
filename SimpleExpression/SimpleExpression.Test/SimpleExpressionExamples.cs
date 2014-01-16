﻿using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SimpleExpressionExamples
    {
        /// http://regexpal.com/

        [TestMethod]
        public void EmailRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Alphanumerics.AtLeast(1)
                .Text("@")
                .Alphanumerics.AtLeast(1)
                .Text(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"\w{1,}@\w{1,}\.\w{2,5}", pattern);
        }

        [TestMethod]
        public void SimpleDate()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.AtLeast(1).AtMost(4)
                .Text('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Text('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", pattern);
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.InRange("1-9999")
                .Text('/')
                .Numbers.InRange("1-12")
                .Text('/')
                .Numbers.InRange("1-31")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])", pattern);
        }

        [TestMethod]
        public void OneConson()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letter
                .Except("aeiou")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z-[aeiou]]", pattern);
        }

        [TestMethod]
        public void SimpleGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aeiou)", pattern);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together.As("vowels")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            var reg = new Regex(pattern);
            Assert.IsTrue(reg.IsMatch("aeiou"));
            var names = reg.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }

        [TestMethod]
        public void BlockRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Text("aei").Repeat.AtLeast(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3,}", pattern);
        }

        [TestMethod]
        public void GroupRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Group
                        .Text("aei")
                    .Together
                    .Repeat.AtLeast(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3,}", pattern);
        }

        [TestMethod]
        public void Repetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Group
                        .Text("aei")
                    .Together
                    .Repeat.Exactly(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3}", pattern);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Text('a')
                .ei
                .Text("ou")
                .Generate();
            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"aeiou", pattern);
        }
    }
}
