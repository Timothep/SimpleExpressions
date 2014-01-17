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
            var result = se
                .Group
                    .Sequence("aei")
                    .Sequence("ou")
                .Together
                .Generate();

            Assert.AreEqual(@"(aeiou)", (result as SimpleExpression).Expression);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Group
                    .Sequence("aei")
                    .Sequence("ou")
                .Together.As("vowels")
                .Generate();

            var pattern = (result as SimpleExpression).Expression;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            var reg = new Regex(pattern);
            Assert.IsTrue(reg.IsMatch("aeiou"));
            var names = reg.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }
    }
}
