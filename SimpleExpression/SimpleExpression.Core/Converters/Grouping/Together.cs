using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class Together:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Together" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add(")");
            return regularExpressionSofar;
        }
    }
}
