﻿using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void OneConson()
        {
            var result = S.Exp()
                .Letter()
                .Except("aeiou");

            Assert.AreEqual(@"[a-zA-Z-[aeiouAEIOU]]*", result.Expression);
        }

        [TestMethod]
        public void ExceptRegex()
        {
            var result = S.Exp()
                .Letter()
                .Except("a-e");

            var pattern = result.Expression;
            Assert.AreEqual(@"[a-zA-Z-[a-eA-E]]*", pattern);

            var reg = new Regex(pattern);
            var matches = reg.Matches("smthng");
            Assert.AreEqual(2, matches.Count);

            matches = reg.Matches("something");
            Assert.AreEqual(4, matches.Count);
        }
    }
}
