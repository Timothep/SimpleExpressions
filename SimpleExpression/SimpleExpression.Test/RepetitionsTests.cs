using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class RepetitionsTests
    {
        [TestMethod]
        public void SequenceRepeatTest()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Repeat.http.Exactly(3).Times
                .Generate();

            Assert.AreEqual(@"(http){3}", (result as SimpleExpression).RegularExpressionPattern);
        }
        
        [TestMethod]
        public void BlockRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Repeat.Sequence("aei").AtLeast(3).Times //AtLeast3Times?
                    .Generate();

            Assert.AreEqual(@"(aei){3,}", (result as SimpleExpression).RegularExpressionPattern);
        }

        [TestMethod]
        public void GroupRepetition()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Repeat
                        .Group.Sequence("aeiou").As("vowels")
                    .AtLeast(3).Times
                    .Generate();

            Assert.AreEqual(@"(?<vowels>(aeiou)){3,}", (result as SimpleExpression).RegularExpressionPattern);
        }

        [TestMethod]
        public void BountRepetitionTests()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Repeat.Sequence("42").AtLeast(2).AtMost(4).Times
                .Generate();

        Assert.AreEqual(@"(42){2,4}", (result as SimpleExpression).RegularExpressionPattern);
        }

        [TestMethod]
        public void FixedRepetitionTests()
        {
            dynamic se = new SimpleExpression();
            var result = se
                    .Repeat.Sequence("42").Exactly(3).Times
                    .Generate();

            Assert.AreEqual(@"(42){3}", (result as SimpleExpression).RegularExpressionPattern);
        }
    }
}
