using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class Runner
    {
        [TestMethod]
        public void Runner_01()
        {
            var emailDetection = new SimpleExpression();

            const string allowedChars = @"!#$%&'*+/=?^_`{|}~-";
            
            emailDetection.Group(Siex.New().Letters().And(allowedChars).AtLeast(1)
                            .Group(Siex.New().One(".").Alphanumerics().And(allowedChars).AtLeast(1))
                            .As("dotAndAfter"));

            Assert.AreEqual("", emailDetection.Expression);
        }
    }
}
