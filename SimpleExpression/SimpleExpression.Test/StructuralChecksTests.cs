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
    public class StructuralChecksTests
    {
        [TestMethod]
        [Ignore]
        public void StructuralChecksTest()
        {
            var command = "Group.http.Together.As(\"Something\")";

            dynamic se = new SimpleExpression();

            SimpleExpression result = se
                .Maybe(".")
                .Sequence("Group")
                .Maybe(".")
                .Alphanumerics
                .Sequence(".Together")
                //.Sequence(".As(\"")
                //.Alphanumerics
                //.Character("\")")
                .Generate();

            var reg = new Regex(result.Expression);
            var matches = reg.Matches(command);

            
        }
    }
}
