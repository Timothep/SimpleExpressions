using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class Anything : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Anything" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add(@".*");
            return regularExpressionSofar;
        }
    }
}
