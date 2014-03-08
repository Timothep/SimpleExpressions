using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void SimpleWordTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Text("ponys")
                .Alphanumerics.And.One(" ")
                .Text("rainbows")
                .Generate();

            Assert.AreEqual(@"\bponys\b[a-zA-Z0-9\s]\brainbows\b", result.Expression);


        }
    }
}
