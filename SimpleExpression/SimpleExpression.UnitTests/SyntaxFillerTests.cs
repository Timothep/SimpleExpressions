using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.EitherOr;
using SimpleExpressions.Core.Converters.Grouping;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Parser;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class SyntaxFillerTests
    {
        [TestMethod]
        public void SyntaxFiller_RepeatBlockExactly()
        {
            var originalChain = new List<IConverter> { new Repeat(), new SimpleSet(), new Exactly(), new Times(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(6, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_RepeatBlockRange()
        {
            var originalChain = new List<IConverter> { new Repeat(), new SimpleSet(), new AtLeast(), new AtMost(), new Times(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(7, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_SimpleBlock_InRange()
        {
            var originalChain = new List<IConverter> { new Text(), new Text(), new SimpleSet(), new InRange(), new Text(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(10, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_PrefixedRepeat()
        {
            var originalChain = new List<IConverter> { new Text(), new SimpleSet(), new Repeat(), new SimpleSet(), new AtLeast(), new AtMost(), new Times(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(11, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_SimpleSets()
        {
            var originalChain = new List<IConverter> { new StartsWith(), new Text(), new Text(), new Text(), new EndOfLine() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(9, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_XOrMore()
        {
            var originalChain = new List<IConverter> { new ZeroOrMore(), new SimpleSet(), new OneOrMore(), new SimpleSet() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(5, modifiedChain.Count);
            Assert.AreEqual(NodeType.HeadOperator, modifiedChain[2].NodeType);
        }

        [TestMethod]
        public void SyntaxFiller_OneOneOf()
        {
            var originalChain = new List<IConverter> { new One(), new OneOf(), new OneOf() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(5, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_Except()
        {
            var originalChain = new List<IConverter> { new SimpleSet(), new Except(), new SimpleSet() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(4, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_ExceptWord()
        {
            var originalChain = new List<IConverter> { new SimpleSet(), new ExceptWord(), new SimpleSet() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(5, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_MaybeOne()
        {
            var originalChain = new List<IConverter> { new Text(), new Maybe(), new One(), new SimpleSet() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(6, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_EitherOf()
        {
            var originalChain = new List<IConverter> { new Text(), new EitherOf(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(5, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_EitherOr()
        {
            var originalChain = new List<IConverter> { new SimpleSet(), new Either(), new One(), new Or(), new Text(), new Then(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(9, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_EitherOrDouble()
        {
            var originalChain = new List<IConverter> { new SimpleSet(), new Either(), new One(), new Text(), new Or(), new Text(), new Then(), new Text() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(11, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_GroupTogether()
        {
            var originalChain = new List<IConverter> { new Text(), new Group(), new Text(), new Text(), new Together() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(7, modifiedChain.Count);
        }

        [TestMethod]
        public void SyntaxFiller_RepeatGroup()
        {
            var originalChain = new List<IConverter> { new Text(), new Repeat(), new Group(), new Text(), new Text(), new As(), new AtLeast(), new Times() };
            var modifiedChain = SyntaxFiller.AddMissingOperators(originalChain);
            Assert.AreEqual(10, modifiedChain.Count);
        }
    }
}
