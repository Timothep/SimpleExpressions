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
            var result = Siex.New()
                .Letters()
                .Except("aeiou");

            Assert.AreEqual(@"[a-zA-Z-[aeiouAEIOU]]*", result.Expression);
        }

        [TestMethod]
        public void ExceptRegex()
        {
            var result = Siex.New()
                .Letters()
                .Except("a-e");

            var pattern =  (result as SimpleExpression).Expression;
            Assert.AreEqual(@"[a-zA-Z-[a-eA-E]]*", pattern);

            var reg = new Regex(pattern);
            var matches = reg.Matches("smthng");
            Assert.AreEqual(2, matches.Count);

            matches = reg.Matches("something");
            Assert.AreEqual(4, matches.Count);
        }
    }
}
