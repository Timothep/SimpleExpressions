using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Times : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> {"Times", "Time"};
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
