using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;
using SimpleExpressions.Core.Rewriters;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class GroupRewriterTests
    {
        [TestMethod]
        public void GroupRewriter_SinglePositiveGroup()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Text(), new Together() };
            var rewriter = new GroupRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);
        }

        [TestMethod]
        public void GroupRewriter_SinglePositiveNamedGroup()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Text(), new Together(), new As() };
            var rewriter = new GroupRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);
        }

        [TestMethod]
        public void GroupRewriter_DoublePositiveNamedGroup()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Text(), new Together(), new As(), new Group(), new Text(), new Together(), new As() };
            var rewriter = new GroupRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);

            Assert.IsTrue(completedChain[1] is As);
            Assert.IsTrue(completedChain[3] is Together);
            Assert.IsTrue(completedChain[5] is As);
            Assert.IsTrue(completedChain[7] is Together);
        }

        [TestMethod]
        public void GroupRewriter_DoublePositiveGroup()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Text(), new Together(), new Group(), new Text(), new Together() };
            var rewriter = new GroupRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);
        }

        [TestMethod]
        public void GroupRewriter_ImbricatedPositiveGroup()
        {
            IList<IConverter> converterChain = new List<IConverter> { new Group(), new Group(), new Text(), new Together(), new As(), new Together() };
            var rewriter = new GroupRewriter();
            var completedChain = rewriter.CompleteConverterChain(converterChain);
        }
    }
}
