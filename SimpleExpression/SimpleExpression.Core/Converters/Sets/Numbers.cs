using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class Numbers : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Numbers" };

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("0-9");
            return regularExpressionSofar;
        }
    }
}