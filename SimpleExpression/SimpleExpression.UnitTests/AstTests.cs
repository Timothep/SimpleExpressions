﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.AbstractTree;
using SimpleExpressions.Core.AbstractTree.Builders;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;
using SimpleExpressions.Core.Converters.Repetitions;

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
            var chain = new List<IConverter> {new Text(), new Text()};
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
            var chain = new List<IConverter> {new Text(), new Text(), new Text()};
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);
            Assert.IsTrue(root is ConcatNode);
            var concatNode = root as ConcatNode;
            Assert.IsTrue(concatNode.Children.Count == 3);
        }

        [TestMethod]
        public void AstTests_SimpleGroup()
        {
            var chain = new List<IConverter> {new Group(), new Text(), new Together()};
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);
        }

        [TestMethod]
        public void AstTests_GroupAndConcat()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new Text(),
                    new Text(),
                    new Together()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);

            var concatNode = groupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(concatNode);
            Assert.IsTrue(concatNode.Children.Count == 2);
        }

        [TestMethod]
        public void AstTests_GroupContainsGroup()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new Group(),
                    new Text(),
                    new Together(),
                    new Together()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);

            var subGroupNode = groupNode.Children[0] as GroupNode;
            Assert.IsNotNull(subGroupNode);
            Assert.IsTrue(subGroupNode.Children.Count == 1);
        }

        [TestMethod]
        public void AstTests_GroupConcatAndContainsGroupConcat()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new Text(),
                    new Group(),
                    new Text(),
                    new Text(),
                    new Together(),
                    new Together()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);

            var concatNode = groupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(concatNode);
            Assert.IsTrue(concatNode.Children.Count == 2);

            var textNode = concatNode.Children[0] as TextNode;
            Assert.IsNotNull(textNode);

            var subGroupNode = concatNode.Children[1] as GroupNode;
            Assert.IsNotNull(subGroupNode);
            Assert.IsTrue(subGroupNode.Children.Count == 1);

            var subConcatNode = subGroupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(subConcatNode);
            Assert.IsTrue(subConcatNode.Children.Count == 2);
        }

        [TestMethod]
        public void AstTests_GroupTogether()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new Group(),
                    new Text(),
                    new Together(),
                    new Text(),
                    new Together()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);

            var concatNode = groupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(concatNode);
            Assert.IsTrue(concatNode.Children.Count == 2);

            var textNode = concatNode.Children[1] as TextNode;
            Assert.IsNotNull(textNode);

            var subGroupNode = concatNode.Children[0] as GroupNode;
            Assert.IsNotNull(subGroupNode);
            Assert.IsTrue(subGroupNode.Children.Count == 1);

            var subConcatNode = subGroupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(subConcatNode);
            Assert.IsTrue(subConcatNode.Children.Count == 1);
        }

        [TestMethod]
        public void AstTests_GroupTogetherAs()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new Text(),
                    new Text(),
                    new Together(),
                    new As()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);

            var concatNode = groupNode.Children[0] as ConcatNode;
            Assert.IsNotNull(concatNode);
            Assert.IsTrue(concatNode.Children.Count == 2);
        }

        [TestMethod]
        public void AstTests_GroupRepetition()
        {
            var chain = new List<IConverter>
                {
                    new Group(),
                    new AtLeast {Function = new Function("AtLeast", new object[] {2})},
                    new AtMost {Function = new Function("AtMost", new object[] {4})},
                    new Text(),
                    new Together()
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var groupNode = root as GroupNode;
            Assert.IsNotNull(groupNode);
            Assert.IsTrue(groupNode.Children.Count == 1);
            Assert.AreEqual(2, groupNode.Cardinality.Min);
            Assert.AreEqual(4, groupNode.Cardinality.Max);
        }

        [TestMethod]
        public void AstTests_Maybe()
        {
            var chain = new List<IConverter>
                {
                    new Text {Function = new Function("Text", new object[] {"http"})},
                    new Maybe {Function = new Function("Maybe", new object[] {"s"})},
                    new Text {Function = new Function("Text", new object[] {"://"})},
                };
            var root = builder.GenerateAst(chain);

            Assert.IsTrue(root != null);
            Assert.IsTrue(root.Parent == null);

            var concatNode = root as ConcatNode;
            Assert.IsNotNull(concatNode);
            Assert.IsTrue(concatNode.Children.Count == 3);

            Assert.IsTrue(concatNode.Children[1] is MaybeNode);
        }
    }
}