using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Converters.Sets;
using SimpleExpressions.Core.Rewriters;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class SetRewriterTests
    {
        [TestMethod]
        public void SetRewriter_Numbers()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Numbers() };
            var rewriter = new SetRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Numbers, "Numbers");
        }

        [TestMethod]
        public void SetRewriter_NumbersInRange()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Numbers(), new InRange() };
            var rewriter = new SetRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is SetBegin, "SetBegin");
            Assert.IsTrue(completedChain[1] is Numbers, "Numbers");
            Assert.IsTrue(completedChain[2] is InRange, "InRange");
            Assert.IsTrue(completedChain[3] is SetEnd, "SetEnd");
        }

        [TestMethod]
        public void SetRewriter_LettersExcept()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Letters(), new Except() };
            var rewriter = new SetRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is SetBegin, "SetBegin");
            Assert.IsTrue(completedChain[1] is Letters, "Letters");
            Assert.IsTrue(completedChain[2] is Except, "Except");
            Assert.IsTrue(completedChain[3] is SetEnd, "SetEnd");
        }

        [Ignore]
        [TestMethod] //Should be handled in a different rewriter?
        public void SetRewriter_GroupCanReplaceSet()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Letters(), new Except(), new Together() };
            var rewriter = new SetRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Group, "Group");
            Assert.IsTrue(completedChain[1] is Letters, "Letters");
            Assert.IsTrue(completedChain[2] is Except, "Except");
            Assert.IsTrue(completedChain[3] is Together, "Together");
        }

        [Ignore]
        [TestMethod] //Should be handled in a different rewriter?
        public void SetRewriter_RepeatCanReplaceSet()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Repeat(), new Letters(), new Except(), new Exactly(), new Times() };
            var rewriter = new SetRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Repeat, "Repeat");
            Assert.IsTrue(completedChain[1] is Letters, "Letters");
            Assert.IsTrue(completedChain[2] is Except, "Except");
            Assert.IsTrue(completedChain[3] is Times, "Times");
            Assert.IsTrue(completedChain[4] is Exactly, "Exactly");
        }
    }
}
