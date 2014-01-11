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
                .Alphanumerics.AtLeast(1)
                .One("@")
                .Alphanumerics.AtLeast(1)
                .One(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
            var pattern = (result as SimpleExpression).Pattern;
            Assert.AreEqual(@"\w{1,}@\w{1,}\.\w{2,5}", pattern);
        }
    }
}
