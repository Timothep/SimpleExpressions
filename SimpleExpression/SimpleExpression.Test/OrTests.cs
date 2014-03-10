using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    [TestClass]
    public class OrTests
    {
        [Ignore]
        [TestMethod]
        public void SimpleOr()
        {
            
            var result = Siex.New()
                .Text("http")
                //.Or()
                .Text("ftp")
                ;

            Assert.AreEqual("(http|ftp)", result.Expression);
        }
    }
}
