using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    public class GroupExpression : SimpleExpression
    {
        public GroupExpression()
        {
            Group(One("a").One("b"))
                .Generate();
            
            //    .One("A").Or.One("X")
            //.Anonymously
            //.One("B")
            //    .Or
            //.One("Y");
        }
    }

    [TestClass]
    public class GroupExpressionTest
    {
        [TestMethod]
        public void Test()
        {
            var gp = new GroupExpression();
            Assert.AreEqual("", gp.Expression);
        }
    }
}