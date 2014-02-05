using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    class RepeatWildcard : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "RepeatWildcard" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("*");
            return regularExpressionSofar;
        }
    }
}
