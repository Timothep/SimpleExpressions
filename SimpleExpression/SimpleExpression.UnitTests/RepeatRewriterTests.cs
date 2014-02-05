using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Repetitions;
using SimpleExpressions.Core.Rewriters;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class RepeatRewriterTests
    {
        [TestMethod]
        public void RepeatRewriter_SinglePositiveLeastMostRepeat()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Repeat(), new Text(), new AtLeast(), new AtMost(), new Times() };
            var rewriter = new RepeatRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Repeat);
            Assert.IsTrue(completedChain[1] is Text);
            Assert.IsTrue(completedChain[2] is Times);
            Assert.IsTrue(completedChain[3] is RepetitionQualifier);
            Assert.IsTrue(completedChain[4] is AtLeast);
            Assert.IsTrue(completedChain[5] is AtMost);
            Assert.IsTrue(completedChain[6] is EndRepetitionQualifier);
        }

        [TestMethod]
        public void RepeatRewriter_SinglePositiveExactlyRepeat()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Repeat(), new Text(), new Exactly(), new Times() };
            var rewriter = new RepeatRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Repeat);
            Assert.IsTrue(completedChain[1] is Text);
            Assert.IsTrue(completedChain[2] is Times);
            Assert.IsTrue(completedChain[3] is RepetitionQualifier);
            Assert.IsTrue(completedChain[4] is Exactly);
            Assert.IsTrue(completedChain[5] is EndRepetitionQualifier);
        }

        [TestMethod]
        public void RepeatRewriter_ImbricatedRepeat()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Repeat(), new Text(), new Repeat(), new Text(), new AtLeast(), new AtMost(), new Times(), new Text(), new Exactly(), new Times() };
            var rewriter = new RepeatRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[0] is Repeat);
            Assert.IsTrue(completedChain[1] is Text);
            Assert.IsTrue(completedChain[2] is Repeat);
            Assert.IsTrue(completedChain[3] is Text);
            Assert.IsTrue(completedChain[4] is Times);
            Assert.IsTrue(completedChain[5] is RepetitionQualifier);
            Assert.IsTrue(completedChain[6] is AtLeast);
            Assert.IsTrue(completedChain[7] is AtMost);
            Assert.IsTrue(completedChain[8] is EndRepetitionQualifier);
            Assert.IsTrue(completedChain[9] is Text);
            Assert.IsTrue(completedChain[10] is Times);
            Assert.IsTrue(completedChain[11] is RepetitionQualifier);
            Assert.IsTrue(completedChain[12] is Exactly);
            Assert.IsTrue(completedChain[13] is EndRepetitionQualifier);
        }
    }
}
