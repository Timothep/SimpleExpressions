using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [Ignore]
    [TestClass]
    public class StructuralChecksTests
    {
        [TestMethod]
        public void GroupTogetherAsStructuralChecksTest()
        {
            

            var result = Siex.New()
                .Text("Group")//.Anything()
                .Text("Together").Maybe(".As")
                ;

            Assert.AreEqual(@"Group.*Together(.As)?", result.Expression);

            var regex = new Regex(result.Expression);
            Assert.IsTrue(regex.IsMatch("Group.http).As(\"Something\")"));
        }

        [TestMethod]
        public void RepeatAtLeastAtMostTimesStructuralChecksTest()
        {
            var result = Siex.New()
                //.StartsWith
                .Either(Siex.New()
                    .Group(Siex.New()
                        .Text("AtLeast").One("\\(").Numbers().AtLeast(1).One("\\)")
                        .Maybe("\\.AtMost").One("\\(").Numbers().AtLeast(1).One("\\)")))
                .Or(Siex.New()
                    .Group(Siex.New().Text("Exactly").One("\\(").Numbers().AtLeast(1).One("\\)")))
                .Text("\\.Times")
                ;


            const string desiredPattern = @"^((AtLeast\([0-9]{1,}\)(\.AtMost\([0-9]{1,}\))?)|(Exactly\([0-9]{1,}\))).Times";
            
            Assert.AreEqual(desiredPattern, result.Expression);
            var regex = new Regex(result.Expression, RegexOptions.ExplicitCapture);

            //Positive tests
            Assert.IsTrue(regex.IsMatch("AtLeast(2).Times"), "AtLeast");
            Assert.IsTrue(regex.IsMatch("AtLeast(2).AtMost(5).Times"), "AtLeast.AtMost");
            Assert.IsTrue(regex.IsMatch("Exactly(2).Times"), "Exactly");
            
            //Negative tests
            Assert.IsFalse(regex.IsMatch("AtMost(2).AtLeast(2).Times"), "AtMost.AtLeast");
            Assert.IsFalse(regex.IsMatch("Exactly(2).AtLeast(5).Times"), "Exactly.AtLeast");
            Assert.IsFalse(regex.IsMatch("Exactly(2).AtMost(5).Times"), "Exactly.AtMost");
        }

        [TestMethod]
         
        public void RepeatAtLeastAtMostTimesStructuralChecksTest2()
        {
            
            var result = Siex.New()
                 //.StartsWith
                 .Group(Siex.New()
                 .Text("Repeat")//.Anything
                    .Either(Siex.New()
                        .Text("AtLeast")//.Anything
                        .Maybe("AtMost")//.Anything
                    )
                    .Or(Siex.New()
                        .Text("Exactly")//.Anything
                    )
                    .Text("Times")
                ).As("Whole")
                //.EndOfLine
                ;

            var regex = new Regex(result.Expression, RegexOptions.ExplicitCapture);
            Assert.IsTrue(regex.IsMatch("Repeat.http.AtLeast(2).Times"), "AtLeast");
            Assert.IsTrue(regex.IsMatch("Repeat.http.AtLeast(2).AtMost(5).Times"), "AtLeast.AtMost");
            Assert.IsTrue(regex.IsMatch("Repeat.http.Exactly(2).Times"), "Exactly");

            //Wrong, the produced regex has too many wildcards that make the matching succeed in those cases
            Assert.IsFalse(regex.IsMatch("Repeat.http.AtMost(2).AtLeast(2).Times"), "AtMost.AtLeast");
            Assert.IsFalse(regex.IsMatch("Repeat.http.Exactly(2).AtLeast(5).Times"), "Exactly.AtLeast");
            Assert.IsFalse(regex.IsMatch("Repeat.http.Exactly(2).AtMost(5).Times"), "Exactly.AtMost");
        }
    }
}
