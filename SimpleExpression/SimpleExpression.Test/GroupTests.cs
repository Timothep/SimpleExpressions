using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void SimpleGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Sequence("aei")
                    .Sequence("ou")
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
                    .Sequence("aei")
                    .Sequence("ou")
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
    }
}
