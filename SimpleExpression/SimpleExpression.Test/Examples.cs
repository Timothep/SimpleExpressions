using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class Examples
    {
        [Ignore]
        [TestMethod]
        public void HttpFtpLinkMatch()
        {
            dynamic se = new SimpleExpression();

            var result = se
                .Group.Text("http").Then.Maybe("s").Together
                .Or.Text("ftp")
                .Then.Text("://").Then.Maybe("www.").Then.OneOrMore.AnythingBut(" ")
                .Generate();

            //Match the result...
        }
    }
}
