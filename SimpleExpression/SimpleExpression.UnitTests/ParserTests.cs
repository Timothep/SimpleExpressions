using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Parser;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Parser_Empty()
        {
            IList<IConverter> chain = new List<IConverter>(0);
            var parser = new Parser();
            var root = parser.Parse(chain);
            Assert.IsNull(root);
        }

        [TestMethod]
        public void Parser_OneText()
        {
            IList<IConverter> chain = new List<IConverter> { new Text() };
            IList<IConverter> stack = chain.Reverse().ToList();
            var parser = new Parser();
            var root = parser.Parse(stack);
            Assert.IsNotNull(root);
            Assert.IsTrue(root.Converter is Text);
        }

        [TestMethod]
        public void Parser_TwoTexts()
        {
            IList<IConverter> chain = new List<IConverter> { new Text(), new FollowedBy(), new Text() };
            IList<IConverter> stack = chain.Reverse().ToList();
            var parser = new Parser();
            var root = parser.Parse(stack);

            Assert.IsNotNull(root);
            Assert.IsTrue(root.Converter is FollowedBy, "Root isn't FollowedBy");
            Assert.IsTrue(root.LeftChild.Converter is Text, "LeftChild isn't Text");
            Assert.IsTrue(root.RightChild.Converter is Text, "RightChild isn't Text");
        }
    }
}
