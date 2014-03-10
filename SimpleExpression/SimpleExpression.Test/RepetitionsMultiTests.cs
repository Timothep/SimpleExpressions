using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [Ignore]
    [TestClass]
    public class RepetitionsMultiTests
    {
        private readonly CardinalityTests cardinalityTests = new CardinalityTests();

        [Ignore]
        [TestMethod]
        public void SequenceRepeatTest()
        {
            
            var result = Siex.New()
                    //.Repeat
                        .Text("http")
                    .Exactly(3)
                    //.Times
                    ;

            Assert.AreEqual(@"(http){3}", result.Expression);
        }
        
        //[Ignore]
        //[TestMethod]
        //public void BlockRepetition()
        //{
        //    
        //    var result = Siex.New()
        //            .Repeat
        //                .Text("aei")
        //            .AtLeast(3)
        //            .Times //AtLeast3Times?
        //            ;

        //    Assert.AreEqual(@"(aei){3,}", result.Expression);
        //}

        // //The "Group/Repeat...Times/Together" Produces a double "(())"
        //[TestMethod]
        //public void GroupRepetition()
        //{
        //    
        //    var result = Siex.New()
        //            .Group(Siex.New().AtLeast(3)
        //                .Text("houuu")
        //            )
        //            .As("ghost")
        //            ;

        //    Assert.AreEqual(@"(?<ghost>houuu){3,}", result.Expression);
        //}

        //[Ignore]
        //[TestMethod]
        //public void BountRepetitionTests()
        //{
        //    
        //    var result = Siex.New()
        //            .Repeat
        //                .Text("42")
        //            .AtLeast(2)
        //            .AtMost(4)
        //            .Times
        //            ;

        //Assert.AreEqual(@"(42){2,4}", result.Expression);
        //}

        //[Ignore]
        //[TestMethod]
        //public void FixedRepetitionTests()
        //{
        //    
        //    var result = Siex.New()
        //            .Repeat
        //                .Text("42")
        //            .Exactly(3)
        //            .Times
        //            ;

        //    Assert.AreEqual(@"(42){3}", result.Expression);
        //}
    }
}
