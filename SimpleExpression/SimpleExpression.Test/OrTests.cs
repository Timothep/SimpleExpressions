using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class OrTests
    {
        [TestMethod]
        public void SimpleOr()
        {
            var result = S.Exp()
                .Either(S.Exp().Text("http"))
                .Or(S.Exp().Text("ftp"));

            Assert.IsTrue(result.IsMatch("http"));
            Assert.IsTrue(result.IsMatch("ftp"));
            Assert.IsFalse(result.IsMatch("htts"));
            Assert.IsFalse(result.IsMatch("godzilla"));
        }
    }
}
