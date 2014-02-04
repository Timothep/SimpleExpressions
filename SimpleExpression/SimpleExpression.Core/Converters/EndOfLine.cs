using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace SimpleExpressions.Core.Converters
{
    public class EndOfLine : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "EndOfLine" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("$"); //Should be the very last?
            return regularExpressionSofar;
        }
    }
}
