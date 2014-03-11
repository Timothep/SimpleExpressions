using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class RepetitionTests
    {
        [TestMethod]
        public void SimpleRepetitionTests()
        {
            var se = new SimpleExpression();
            Assert.AreEqual("[0-9]{2,}", se.Number().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z]{2,}", se.Letter().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z0-9]{2,}", se.Alphanumeric().AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("a{2,}", se.One('a').AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(a|b|cd){2,}", se.OneOf("a|b|cd").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(a|b|cd){2,}", se.EitherOf("a|b|cd").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("([0-2]|3){2,}", se.NumberInRange("0-3").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-cA-C]{2,}", se.LetterInRange("a-c").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("([a-zA-Z]*){2,}", se.Group(S.Exp().Letter()).AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("(?<letters>[a-zA-Z]*){2,}", se.Group(S.Exp().Letter()).AtLeast(2).As("letters").Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z~]{2,}", se.Letter().And("~").AtLeast(2).Expression);

            se = new SimpleExpression();
            Assert.AreEqual("[a-zA-Z-[zZ]]{2,}", se.Letter().Except("z").AtLeast(2).Expression);
        }
    }
}
