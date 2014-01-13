using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExpressions.Core;

namespace SimpleExpressions.Test
{
    public class TestExpression: SimpleExpression
    {
        public TestExpression()
        {
            var result = Alphanumerics.Generate();
        }
    }
}
