using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class Alphanumerics : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> {"Alphanumerics"};

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("a-zA-Z0-9");
            return regularExpressionSofar;
        }
    }
}
