using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class Runner
    {
        [TestMethod]
        public void Runner_01()
        {
            //var emailDetection = new SimpleExpression();

            //const string allowedChars = @"!#$%&'*+/=?^_`{|}~-";
            
            //emailDetection.Group(S.Exp().Letter().And(allowedChars).AtLeast(1)
            //                .Group(S.Exp().One('.").Alphanumeric().And(allowedChars).AtLeast(1))
            //                .As("dotAndAfter"));

            //Assert.AreEqual("", emailDetection.Expression);

            SimpleExpression emailDetection = new SimpleExpression(),
                beforeDot = new SimpleExpression(),
                dotAndAfter = new SimpleExpression(),
                dotAndBefore = new SimpleExpression();


            string allowedChars = @"!#$%&'*+/=?^_`{|}~-";

            beforeDot.Alphanumeric().And(allowedChars).AtLeast(1);

            dotAndAfter.One('.')
                    .Alphanumeric()
                    .And(allowedChars).AtLeast(1);

            dotAndBefore.Alphanumeric().And("-")
                .Alphanumeric().Exactly(1);

            emailDetection
                .SubExpression(beforeDot)
                .Group(dotAndAfter).AtLeast(0)
                .One('@')
                .Group(new SimpleExpression()
                    .Letter().Exactly(1)
                    .Alphanumeric()
                    .Group(dotAndBefore).AtMost(1)
                    .One('.'))        
                    .Either(S.Exp().Letter()).Or(S.Exp().Letter())
                .AtLeast(1);

            Console.WriteLine(emailDetection.Expression);
        }
    }
}
