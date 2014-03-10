using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class OrTests
    {
        [TestMethod]
        public void SimpleOr()
        {
            var result = Siex.New()
                .Either(Siex.New().Text("http"))
                .Or(Siex.New().Text("ftp"));

            Assert.IsTrue(result.IsMatch("http"));
            Assert.IsTrue(result.IsMatch("ftp"));
            Assert.IsFalse(result.IsMatch("htts"));
            Assert.IsFalse(result.IsMatch("godzilla"));
        }
    }
}
