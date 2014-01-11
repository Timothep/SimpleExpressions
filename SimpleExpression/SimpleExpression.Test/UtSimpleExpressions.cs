using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class UtSimpleExpressions
    {
        [TestMethod]
        public void EmailRegex()
        {
            dynamic se = new SimpleExpression("abcdefg");
            var result = se
                .Alphanumerics
                .One("@")
                .Alphanumerics
                .One(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
        }
    }
}
