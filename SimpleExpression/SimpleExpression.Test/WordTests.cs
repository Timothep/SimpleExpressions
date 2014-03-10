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
            var result = Siex.New()
                .Text("ponys")
                .Alphanumerics().And(" ")
                .Text("rainbows");

            Assert.AreEqual(@"ponys[a-zA-Z0-9 ]*rainbows", result.Expression);
        }
    }
}
