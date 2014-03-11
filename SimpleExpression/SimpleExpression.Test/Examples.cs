using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class Examples
    {
        [TestMethod]
        public void HttpFtpLinkMatch()
        {
            var result = S.Exp()
                            .Either(S.Exp()
                                .Group(S.Exp().Text("http").Maybe("s")))
                            .Or(S.Exp().Text("ftp"))
                            .Text("://")
                            .Maybe("www.")
                            .Alphanumeric()
                            .And("-_.").AtLeast(1);

            Assert.IsTrue(result.IsMatch("http://www.something"));
            Assert.IsTrue(result.IsMatch("https://www.something"));
            Assert.IsTrue(result.IsMatch("ftp://www.something"));
            Assert.IsTrue(result.IsMatch("http://www.something.com"));

            Assert.IsFalse(result.IsMatch("ftps://www.something"));
        }
    }
}
