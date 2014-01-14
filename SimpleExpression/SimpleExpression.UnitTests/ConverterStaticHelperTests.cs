using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;

namespace SimpleExpression.UnitTests
{
    [TestClass]
    public class ConverterStaticHelperTests
    {
        [TestMethod]
        public void FindMatchingParenthesisIndexOneToken()
        {
            var pattern = new List<string> { "()" };

            var tupleToMatch = new Tuple<int, int>(0, 1);
            var matchingTuple = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, tupleToMatch);

            Assert.AreEqual(0, matchingTuple.Item1);
            Assert.AreEqual(0, matchingTuple.Item2);
        }

        [TestMethod]
        public void FindMatchingParenthesisIndexOneTokenWithGaps()
        {
            var pattern = new List<string> { " ( ) " };

            var tupleToMatch = new Tuple<int, int>(0, 3);
            var matchingTuple = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, tupleToMatch);

            Assert.AreEqual(0, matchingTuple.Item1);
            Assert.AreEqual(1, matchingTuple.Item2);
        }

        [TestMethod]
        public void FindMatchingParenthesisIndexTwoTokens()
        {
            var pattern = new List<string> { "(",")" };

            var tupleToMatch = new Tuple<int, int>(1, 0);
            var matchingTuple = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, tupleToMatch);

            Assert.AreEqual(0, matchingTuple.Item1);
            Assert.AreEqual(0, matchingTuple.Item2);
        }

        [TestMethod]
        public void FindMatchingParenthesisIndexTwoTokensWithGaps()
        {
            var pattern = new List<string> { " ( "," ) " };

            var tupleToMatch = new Tuple<int, int>(1, 1);
            var matchingTuple = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, tupleToMatch);

            Assert.AreEqual(0, matchingTuple.Item1);
            Assert.AreEqual(1, matchingTuple.Item2);
        }

        [TestMethod]
        public void FindMatchingParenthesisIndex()
        {
            var pattern = new List<string> { "(","(a)","(","(b)","(c)",")",")", };

            var tupleToMatch = new Tuple<int, int>(6, 0);
            var matchingTuple = ConverterStaticHelper.FindMatchingParenthesisIndex(pattern, tupleToMatch);

            Assert.AreEqual(0, matchingTuple.Item1);
            Assert.AreEqual(0, matchingTuple.Item2);
        }
    }
}
