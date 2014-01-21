using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.Converters;
using Group = System.Text.RegularExpressions.Group;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class StructuralChecksTests
    {
        [TestMethod]
        public void GroupTogetherAsStructuralChecksTest()
        {
            dynamic se = new SimpleExpression();

            SimpleExpression result = se
                .Text("Group").Anything
                .Text("Together").Maybe(".As")
                .Generate();

            Assert.AreEqual(@"Group.*Together(.As)?", result.Expression);

            var regex = new Regex(result.Expression);
            Assert.IsTrue(regex.IsMatch("Group.http.Together.As(\"Something\")"));
        }

        [TestMethod]
        public void RepeatAtLeastAtMostTimesStructuralChecksTest()
        {
            dynamic se = new SimpleExpression();

            SimpleExpression result = se
                .StartsWith
                .Either
                    .Group
                        .Text("AtLeast").One("\\(").Number.AtLeast(1).One("\\)")
                        .Maybe("\\.AtMost").One("\\(").Number.AtLeast(1).One("\\)")
                    .Together
                .Or
                    .Group
                        .Text("Exactly").One("\\(").Number.AtLeast(1).One("\\)")
                    .Together
                    .Then
                .Text("\\.Times")
                .Generate();


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
        [Ignore]
        public void RepeatAtLeastAtMostTimesStructuralChecksTest2()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                 .StartsWith
                 .Group
                 .Text("Repeat").Anything
                    .Either
                        .Text("AtLeast").Anything
                        .Maybe("AtMost").Anything
                    .Or
                        .Text("Exactly").Anything
                    .Then
                    .Text("Times")
                .Together.As("Whole")
                .EndOfLine
                .Generate();

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
