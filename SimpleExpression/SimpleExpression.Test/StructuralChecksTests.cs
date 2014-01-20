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
                .Sequence("Group").Anything
                .Sequence("Together").Maybe(".As")
                .Generate();

            Assert.AreEqual(@"Group.*Together(.As)?", result.Expression);

            var regex = new Regex(result.Expression);
            Assert.IsTrue(regex.IsMatch("Group.http.Together.As(\"Something\")"));
        }

        [TestMethod]
        [Ignore]
        public void RepeatAtLeastAtMostTimesStructuralChecksTest()
        {
            dynamic se = new SimpleExpression();

            SimpleExpression result = se
                .StartsWith
                .Sequence("Repeat").Anything
                .Either
                    .Group
                        .Sequence("AtLeast").Anything
                        .Maybe("AtMost").Anything
                    .Together
                .Or
                    .Group
                        .Sequence("Exactly").Anything
                    .Together
                .Sequence("Times")
                .EndOfLine
                .Generate();

            dynamic se2 = new SimpleExpression();
            SimpleExpression result2 = se2
                .Either
                    .Sequence("AtLeast").Anything
                    .Maybe("AtMost").Anything
                .Or
                    .Sequence("Exactly").Anything
                .Then
                .Sequence("Times")
                .EndOfLine
                .Generate();

            //Assert.AreEqual(@"Repeat.*AtLeast.*(AtMost)?.*Times", result.Expression);

            var regex = new Regex(result.Expression, RegexOptions.ExplicitCapture);
            Assert.IsTrue(regex.IsMatch("Repeat.http.AtLeast(2).Times"));
            Assert.IsTrue(regex.IsMatch("Repeat.http.AtLeast(2).AtMost(5).Times"));

            var condition = regex.Match("Repeat.http.Exactly(5).Times");
            Assert.AreEqual("Repeat.http.Exactly(5).Times", condition.Captures[0].Value);
        }
    }
}
