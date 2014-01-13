using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class RangeBuilderTest
    {
        [TestMethod]
        public void SingleDigitStep()
        {
            var range = new List<string>(0);
            RangeBuilder.DecomposeSteps(1, 5, range);
            Assert.AreEqual("5", range[0]);
        }

        [TestMethod]
        public void DoubleDigitStep()
        {
            var range = new List<string>(0);
            RangeBuilder.DecomposeSteps(1, 21, range);
            Assert.AreEqual("10", range[0]);
            Assert.AreEqual("20", range[1]);
        }

        [TestMethod]
        public void TripleDigitStep()
        {
            var range = new List<string>(0);
            RangeBuilder.DecomposeSteps(1, 150, range);
            Assert.AreEqual("10", range[0]);
            Assert.AreEqual("100", range[1]);
        }

        [TestMethod]
        public void CreateRanges()
        {
            Assert.AreEqual("[2-7]|8", RangeBuilder.CreateRange("2-8"));
            Assert.AreEqual("[5-9]|[1-2][0-9]|3[0-5]", RangeBuilder.CreateRange("5-35"));
            Assert.AreEqual("[5-9]|[1-9][0-9]|100", RangeBuilder.CreateRange("5-100"));
            Assert.AreEqual("1[2-9]|[2-9][0-9]|[1-9][0-9][0-9]|1[0-2][0-3][0-4]", RangeBuilder.CreateRange("12-1234"));
            Assert.AreEqual("123", RangeBuilder.CreateRange("123-123"));
            Assert.AreEqual("25[6-9]|2[6-9][0-9]|3[0-2][0-1]", RangeBuilder.CreateRange("256-321"));
            Assert.AreEqual("256|257", RangeBuilder.CreateRange("256-257"));
            Assert.AreEqual("18[0-9]|19[0-5]", RangeBuilder.CreateRange("180-195"));
        }
    }
}
