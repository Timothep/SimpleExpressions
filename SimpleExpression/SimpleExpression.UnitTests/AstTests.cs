using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.AbstractTree;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class AstTests
    {
        private readonly AstBuilder builder = new AstBuilder();

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void AstTests_NullChain()
        {
            var root = this.builder.GenerateAst(null);

            Assert.IsNull(root);
        }

        [TestMethod]
        public void AstTests_EmptyChain()
        {
            var chain = new List<IConverter>(0);
            var root = builder.GenerateAst(chain);

            Assert.IsNull(root);
        }

        [TestMethod]
        public void AstTests_SimpleConcat()
        {
            var chain = new List<IConverter> { new Text(), new Text() };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);
            Assert.IsTrue(root is ConcatNode);
            var concatNode = root as ConcatNode;
            Assert.IsTrue(concatNode.Children.Count == 2);
        }

        [TestMethod]
        public void AstTests_MoreConcat()
        {
            var chain = new List<IConverter> { new Text(), new Text(), new Text() };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);
            Assert.IsTrue(root is ConcatNode);
            var concatNode = root as ConcatNode;
            Assert.IsTrue(concatNode.Children.Count == 3);
        }

        [TestMethod]
        public void AstTests_Group()
        {
            var chain = new List<IConverter> { new Group(), new Text(), new Text(), new Together() };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);
            Assert.IsTrue(root is GroupNode);
            var groupNode = root as GroupNode;
            Assert.IsTrue(groupNode.Children.Count == 2);
        }
    }
}
