using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class SetBegin : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "SetBegin" };

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
