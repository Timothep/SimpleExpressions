using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.SyntaxTree;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void TestNode()
        {
            var tree = Tokenizer.PlantTree();
        }
    }
}
