using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class EitherOrThen
    {
         
        [TestMethod]
        public void SimpleEitherOr()
        {
            dynamic se = new SimpleExpression();

            var result = se
                .Numbers.AtLeast(1)
                .Maybe(" ")
                .One("€")
                .Or
                .Text("EURO")
                //.Then //Can be omited
                .Generate();

            Assert.AreEqual("[0-9]{1,}( )?(€|EURO)", result.Expression);
        }
    }
}
