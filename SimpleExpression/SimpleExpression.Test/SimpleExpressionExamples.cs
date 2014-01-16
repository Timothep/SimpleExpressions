using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SimpleExpressionExamples
    {
        /// http://regexpal.com/
        /// http://regexstorm.net/tester

        [TestMethod]
        public void EmailRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Alphanumerics.AtLeast(1)
                .Text("@")
                .Alphanumerics.AtLeast(1)
                .Text(".")
                .Alphanumerics.AtLeast(2).AtMost(5)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z0-9]{2,5}", pattern);
        }

        [TestMethod]
        public void SimpleDate()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Numbers.AtLeast(1).AtMost(4)
                .Text('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Text('/')
                .Numbers.AtLeast(1).AtMost(2)
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", pattern);
        }

        [TestMethod]
        public void SimpleGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aeiou)", pattern);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together.As("vowels")
                .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            var reg = new Regex(pattern);
            Assert.IsTrue(reg.IsMatch("aeiou"));
            var names = reg.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }

        [TestMethod]
        public void BlockRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Text("aei").Repeat.AtLeast(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3,}", pattern);
        }

        [TestMethod]
        public void GroupRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Group
                        .Text("aei")
                    .Together
                    .Repeat.AtLeast(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3,}", pattern);
        }

        [TestMethod]
        public void Repetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Group
                        .Text("aei")
                    .Together
                    .Repeat.Exactly(3)
                    .Generate();

            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"(aei){3}", pattern);
        }

        [TestMethod]
        public void ExactMatchRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Text('a')
                .ei
                .Text("ou")
                .Generate();
            Assert.IsNotNull(result);
            var simpleExpression = result as SimpleExpression;
            Assert.IsNotNull(simpleExpression);

            var pattern = simpleExpression.RegularExpressionPattern;
            Assert.AreEqual(@"aeiou", pattern);
        }

    }
}

