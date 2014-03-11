using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void SimpleGroup()
        {
            var result = new SimpleExpression()
                    .Group(S.Exp()
                        .Text("aei")
                        .Text("ou"));

            Assert.AreEqual(@"(aeiou)", result.Expression);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            var result = S.Exp()
                .Group(S.Exp()
                    .Text("aei")
                    .Text("ou"))
                .As("vowels");

            var pattern = result.Expression;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            Assert.IsTrue(result.IsMatch("aeiou"));
            var names = result.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }
    }
}
