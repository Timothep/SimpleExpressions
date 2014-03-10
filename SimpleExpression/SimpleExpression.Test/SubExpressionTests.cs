using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SubExpressionTests
    {
        [TestMethod]
        public void SimpleSubExpression()
        {
            dynamic subSe = new SimpleExpression();
            SimpleExpression subResult = subSe
                .Text("DEF")
                .Generate();

            Assert.AreEqual("DEF", subResult.Expression);

            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Text("ABC")
                .SubExpression(subSe)
                .Text("GHI")
                .Generate();

            Assert.AreEqual("ABCDEFGHI", result.Expression);
            Assert.IsTrue(result.IsMatch("ABCDEFGHI"));
        }
    }
}
