using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class LengthBounds
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

            Assert.AreEqual(@"[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z0-9]{2,5}", (result as SimpleExpression).RegularExpressionPattern);
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

            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", (result as SimpleExpression).RegularExpressionPattern);
        }
    }
}
