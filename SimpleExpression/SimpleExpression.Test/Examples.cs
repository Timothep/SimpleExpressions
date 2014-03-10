using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class Examples
    {
        [TestMethod]
        public void HttpFtpLinkMatch()
        {
            var result = Siex.New()
                            .Either(Siex.New()
                                .Group(Siex.New().Text("http").Maybe("s")))
                            .Or(Siex.New().Text("ftp"))
                            .Text("://")
                            .Maybe("www.")
                            .Alphanumerics()
                            .And("-_.").AtLeast(1);

            //Assert.AreEqual(@"((http(s)?)|ftp)://(www\.)?[a-zA-Z0-9]*", result.Expression);
            Assert.IsTrue(result.IsMatch("http://www.something"));
            Assert.IsTrue(result.IsMatch("https://www.something"));
            Assert.IsTrue(result.IsMatch("ftp://www.something"));
            Assert.IsTrue(result.IsMatch("http://www.something.com"));

            Assert.IsFalse(result.IsMatch("ftps://www.something"));
        }
    }
}
