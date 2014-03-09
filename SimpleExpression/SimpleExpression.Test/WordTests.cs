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
                .Alphanumerics.And(" ")
                .Text("rainbows")
                .Generate();

            Assert.AreEqual(@"ponys[a-zA-Z0-9 ]*rainbows", result.Expression);
        }
    }
}
