using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class UtSimpleExpressions
    {
        /// http://regexpal.com/

        [TestMethod]
        public void EmailRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Alphanumerics.AtLeast(1)
                .One("@")
                .Alphanumerics.AtLeast(1)
                .One(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.Expression;
            Assert.AreEqual(@"\w{1,}@\w{1,}\.\w{2,5}", pattern);
        }

        [TestMethod]
        public void EmailRegex2()
        {
            var te = new MailExpression();

            var pattern = te.Expression;

            Assert.AreEqual(@"\w{1,}@\w{1,}\.\w{2,5}", pattern);
        }

        [TestMethod]
        public void SimpleDate()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.AtLeast(1).AtMost(4)
                .One('/')
                .Numbers.AtLeast(1).AtMost(2)
                .One('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.Expression;
            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", pattern);
        }

        [TestMethod]
        public void SimpleDateWithRanges()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.InRange("1-9999")
                .One('/')
                .Numbers.InRange("1-12")
                .One('/')
                .Numbers.InRange("1-31")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.Expression;
            Assert.AreEqual(@"([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-8][0-9][0-9][0-9]|9[0-8][0-9][0-9]|99[0-8][0-9]|999[0-9])/([1-9]|1[0-2])/([1-9]|[1-2][0-9]|3[0-1])", pattern);
        }

        [TestMethod]
        public void OneConson()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letter
                .Except("aeiou")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.Expression;
            Assert.AreEqual(@"[a-zA-Z-[aeiou]]", pattern);
        }


    }
}
