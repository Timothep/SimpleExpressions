using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class SubExpressionTests
    {
        [TestMethod]
        public void SimpleSubExpression()
        {
            var subSe = new SimpleExpression();
            SimpleExpression subResult = subSe.Text("DEF");

            Assert.AreEqual("DEF", subResult.Expression);

            var result = S.Exp()
                .Text("ABC")
                .SubExpression(subSe)
                .Text("GHI");

            Assert.AreEqual("ABCDEFGHI", result.Expression);
            Assert.IsTrue(result.IsMatch("ABCDEFGHI"));
        }
    }
}
