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
            var subSe = new SimpleExpression();
            SimpleExpression subResult = subSe
                .Text("DEF")
                ;

            Assert.AreEqual("DEF", subResult.Expression);

            
            var result = Siex.New()
                .Text("ABC")
                .SubExpression(subSe)
                .Text("GHI")
                ;

            Assert.AreEqual("ABCDEFGHI", result.Expression);
            Assert.IsTrue(result.IsMatch("ABCDEFGHI"));
        }
    }
}
