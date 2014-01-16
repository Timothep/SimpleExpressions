using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class InRangeTests
    {
        [TestMethod]
        public void SimpleRangeTest()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers
                .InRange("1-5")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"([1-4]|5)", pattern);
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
    }
}
