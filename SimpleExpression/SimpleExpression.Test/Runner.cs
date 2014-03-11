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
            
            //emailDetection.Group(S.Exp().Letters().And(allowedChars).AtLeast(1)
            //                .Group(S.Exp().One(".").Alphanumerics().And(allowedChars).AtLeast(1))
            //                .As("dotAndAfter"));

            //Assert.AreEqual("", emailDetection.Expression);

            SimpleExpression emailDetection = new SimpleExpression(),
                beforeDot = new SimpleExpression(),
                dotAndAfter = new SimpleExpression(),
                dotAndBefore = new SimpleExpression();


            string allowedChars = @"!#$%&'*+/=?^_`{|}~-";

            beforeDot.Alphanumerics().And(allowedChars).AtLeast(1);

            dotAndAfter.One(".")
                    .Alphanumerics()
                    .And(allowedChars).AtLeast(1);

            dotAndBefore.Alphanumerics().And("-")
                .Alphanumerics().Exactly(1);

            emailDetection
                .SubExpression(beforeDot)
                .Group(dotAndAfter).AtLeast(0)
                .One("@")
                .Group(new SimpleExpression()
                    .Letters().Exactly(1)
                    .Alphanumerics()
                    .Group(dotAndBefore).AtMost(1)
                    .One("."))        
                    .Either(S.Exp().Letter()).Or(S.Exp().Letters())
                .AtLeast(1);

            Console.WriteLine(emailDetection.Expression);
        }
    }
}
