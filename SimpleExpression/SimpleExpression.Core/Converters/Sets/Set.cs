using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class Set : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Set" };

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("[");
            return regularExpressionSofar;
        }
    }
}
