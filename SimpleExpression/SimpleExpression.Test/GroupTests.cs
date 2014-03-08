using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void SimpleGroup()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together
                .Generate();

            Assert.AreEqual(@"(aeiou)", result.Expression);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            dynamic se = new SimpleExpression();
            SimpleExpression result = se
                .Group
                    .Text("aei")
                    .Text("ou")
                .Together.As("vowels")
                .Generate();

            var pattern = (result as SimpleExpression).Expression;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            Assert.IsTrue(result.IsMatch("aeiou"));
            var names = result.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }
    }
}
