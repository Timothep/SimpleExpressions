using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class ZeroOrMore: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "ZeroOrMore" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            return regularExpressionSofar;
        }
    }
}
