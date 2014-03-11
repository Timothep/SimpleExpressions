using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class MaybeTests
    {
        [TestMethod]
        public void SimpleMaybeTest()
        {
            var result = S.Exp()
                .Text("http")
                .Maybe("s")
                .Text("://");

            Assert.AreEqual(@"http(s)?://", result.Expression);
        }
    }
}
