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

            Assert.AreEqual("[0-9]{1,}( )?(€|EURO)", result.Expression);
        }
    }
}
