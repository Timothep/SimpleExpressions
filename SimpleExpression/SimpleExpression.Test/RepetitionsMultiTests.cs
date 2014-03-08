using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
     
    [TestClass]
    public class RepetitionsMultiTests
    {
        private readonly CardinalityTests cardinalityTests = new CardinalityTests();

        [Ignore]
        [TestMethod]
        public void SequenceRepeatTest()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                    .Repeat
                        .Text("http")
                    .Exactly(3)
                    .Times
                    .Generate();

            Assert.AreEqual(@"(http){3}", result.Expression);
        }
        
        [Ignore]
        [TestMethod]
        public void BlockRepetition()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                    .Repeat
                        .Text("aei")
                    .AtLeast(3)
                    .Times //AtLeast3Times?
                    .Generate();

            Assert.AreEqual(@"(aei){3,}", result.Expression);
        }


        [Ignore]
         //The "Group/Repeat...Times/Together" Produces a double "(())"
        [TestMethod]
        public void GroupRepetition()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                    .Repeat
                        .Group
                            .Text("aeiou")
                        .As("vowels")
                    .AtLeast(3).Times
                    .Generate();

            Assert.AreEqual(@"(?<vowels>aeiou){3,}", result.Expression);
        }

        [Ignore]
        [TestMethod]
        public void BountRepetitionTests()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                    .Repeat
                        .Text("42")
                    .AtLeast(2)
                    .AtMost(4)
                    .Times
                    .Generate();

        Assert.AreEqual(@"(42){2,4}", result.Expression);
        }

        [Ignore]
        [TestMethod]
        public void FixedRepetitionTests()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                    .Repeat
                        .Text("42")
                    .Exactly(3)
                    .Times
                    .Generate();

            Assert.AreEqual(@"(42){3}", result.Expression);
        }
    }
}
