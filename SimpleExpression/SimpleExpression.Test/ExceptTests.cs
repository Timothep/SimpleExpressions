using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void OneConson()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letter
                .Except("aeiou")
                .Generate();

            Assert.AreEqual(@"[a-zA-Z-[aeiou]]", (result as SimpleExpression).RegularExpressionPattern);
        }

        [TestMethod]
        public void ExceptRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letters
                .Except("a-e")
                .Generate();

            var pattern =  (result as SimpleExpression).RegularExpressionPattern;
            Assert.AreEqual(@"[a-zA-Z-[a-e]]*", pattern);

            var reg = new Regex(pattern);
            var matches = reg.Matches("smthng");
            Assert.AreEqual(2, matches.Count);

            matches = reg.Matches("something");
            Assert.AreEqual(4, matches.Count);
        }

        [Ignore]
            /* 
             * Make "ponys and unicorns" return one match
             * Make "ponys and rainbows" return zero matches             * 
             */
        [TestMethod]
        public void ExceptWordRegex()
        {
            dynamic se = new SimpleExpression();
            var result = se
                .Letters
                .ExceptWord("rainbow")
                .Generate();

            var pattern =  (result as SimpleExpression).RegularExpressionPattern;
            Assert.AreEqual(@"^(.(?!rainbow))*$", pattern);

            var reg = new Regex(pattern);
            var matches = reg.Matches("ponys and unicorns");
            Assert.AreEqual(2, matches.Count);

            reg = new Regex(pattern);
            matches = reg.Matches("ponys and rainbows");
            Assert.AreEqual(0, matches.Count);
        }
    }
}
