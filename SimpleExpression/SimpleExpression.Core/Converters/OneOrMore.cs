using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class OneOrMore: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "OneOrMore" };
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
