using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
     
    [TestClass]
    public class LengthBoundsTest
    {
        [TestMethod]
        public void EmailRegex()
        {
            
            var result = Siex.New()
                .Alphanumerics().AtLeast(1)
                .One("@")
                .Alphanumerics().AtLeast(1)
                .One(".")
                .Alphanumerics().AtLeast(2).AtMost(5)
                ;

            Assert.AreEqual(@"[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}\.[a-zA-Z0-9]{2,5}", result.Expression);
        }

        [TestMethod]
        public void SimpleDate()
        {
            
            var result = Siex.New()
                .Numbers().AtLeast(1).AtMost(4)
                .One("/")
                .Numbers().AtLeast(1).AtMost(2)
                .One("/")
                .Numbers().AtLeast(1).AtMost(2)
                ;

            Assert.AreEqual(@"[0-9]{1,4}/[0-9]{1,2}/[0-9]{1,2}", result.Expression);
        }
    }
}
