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

            Assert.AreEqual(@"([1-4]|5)", (result as SimpleExpression).RegularExpressionPattern);
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.InRange("1-9999")
                .Character('/')
                .Numbers.InRange("1-12")
                .Character('/')
                .Numbers.InRange("1-31")
                .Generate();

            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])",
                (result as SimpleExpression).RegularExpressionPattern);
        }
    }
}
