using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class RepetitionTests
    {
        [TestMethod]
        public void SimpleRepetitionTests()
        {
            var se = new SimpleExpression();
            Assert.AreEqual("[0-9]{2,}", se.Numbers().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z]{2,}", se.Letters().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z0-9]{2,}", se.Alphanumerics().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("a{2,}", se.One("a").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(a|b|cd){2,}", se.OneOf("a|b|cd").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(a|b|cd){2,}", se.EitherOf("a|b|cd").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("([0-2]|3){2,}", se.NumberInRange("0-3").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-cA-C]{2,}", se.LetterInRange("a-c").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("([a-zA-Z]*){2,}", se.Group(Siex.New().Letters()).AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(?<letters>[a-zA-Z]*){2,}", se.Group(Siex.New().Letters()).AtLeast(2).As("letters").Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z~]{2,}", se.Letters().And("~").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z-[zZ]]{2,}", se.Letters().Except("z").AtLeast(2).Expression);
        }
    }
}
