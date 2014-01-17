using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class RepetitionsTests
    {
        [TestMethod]
        public void EmailRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Alphanumerics.AtLeast(1)
                .Character("@")
                .Alphanumerics.AtLeast(1)
                .Character(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z0-9]{2,5}", pattern);
        }

        [TestMethod]
        public void SimpleDate()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.AtLeast(1).AtMost(4)
                .Character('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Character('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", pattern);
        }

        [TestMethod]
        public void BlockRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Sequence("aei")
                    .Repeat
                    .AtLeast(3)
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
                        .Sequence("aei")
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
                        .Sequence("aei")
                    .Together
                    .Repeat.Exactly(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3}", pattern);
        }
    }
}
