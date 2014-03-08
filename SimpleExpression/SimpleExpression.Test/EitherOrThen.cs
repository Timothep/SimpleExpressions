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
                .OneOrMore.Numbers
                .Maybe(" ")
                .Either
                    .One("€")
                .Or
                    .Text("EURO")
                .Then //Can be omited
                .Generate();

            Assert.IsFalse(true);
        }
    }
}
