﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void SimpleWordTest()
        {
            var result = S.Exp()
                .Text("ponys")
                .Alphanumeric().And(" ")
                .Text("rainbows");

            Assert.AreEqual(@"ponys[a-zA-Z0-9 ]*rainbows", result.Expression);
        }
    }
}
