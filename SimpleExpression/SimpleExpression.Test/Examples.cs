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
            dynamic se = new SimpleExpression();

            var result = se
                .Group
                    .Text("http")
                    .Maybe("s")
                .Together
                .Or
                    .Text("ftp")
                .Then
                .Text("://")
                .Maybe("www.")
                .AnythingBut(" ")
                .Generate();

            //Match the result...
        }
    }
}
