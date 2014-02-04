using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class StartsWith: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "StartsWith" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("^"); //Should be the very first?
            return regularExpressionSofar;
        }
    }
}
