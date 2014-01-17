using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class MaybeTests
    {
        [TestMethod]
        public void SimpleMaybeTest()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .http
                .Maybe("s")
                .Sequence("://")
                .Generate();

            Assert.AreEqual(@"http(s)?://", (result as SimpleExpression).RegularExpressionPattern);
        }
    }
}
