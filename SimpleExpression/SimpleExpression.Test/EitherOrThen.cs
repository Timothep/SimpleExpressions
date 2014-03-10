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
            var result = Siex.New()
                .Numbers().AtLeast(1)
                .Maybe(" ")
                .Either(Siex.New().One("€"))
                .Or(Siex.New().Text("EURO"));

            Assert.IsTrue(result.IsMatch("125€"));
            Assert.IsTrue(result.IsMatch("1 €"));
            Assert.IsTrue(result.IsMatch("0 EURO"));

            Assert.IsFalse(result.IsMatch("d DOLLAR"));
            Assert.IsFalse(result.IsMatch("0 DOLLAR"));
        }
    }
}
