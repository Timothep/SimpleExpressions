using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void SimpleSequenceTest()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Word("ponys")
                .AlphanumericsAndWhitespaces
                .Word("rainbows")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"\bponys\b[a-zA-Z0-9\s]\brainbows\b", pattern);
        }
    }
}
