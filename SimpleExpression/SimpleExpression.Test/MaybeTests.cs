﻿using System;
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
            SimpleExpression result = se
                .http
                .Maybe("s")
                .Text("://")
                .Generate();

            Assert.AreEqual(@"http(s)?://", result.Expression);
        }
    }
}
