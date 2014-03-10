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
            var result = new SimpleExpression()
                    .Group(Siex.New()
                        .Text("aei")
                        .Text("ou"));

            Assert.AreEqual(@"(aeiou)", result.Expression);
        }

        [TestMethod]
        public void SimpleNamedGroup()
        {
            var result = Siex.New()
                .Group(Siex.New()
                    .Text("aei")
                    .Text("ou"))
                .As("vowels")
                ;

            var pattern = result.Expression;
            Assert.AreEqual(@"(?<vowels>aeiou)", pattern);

            Assert.IsTrue(result.IsMatch("aeiou"));
            var names = result.GetGroupNames();
            Assert.AreEqual("vowels", names[1]);
        }
    }
}
