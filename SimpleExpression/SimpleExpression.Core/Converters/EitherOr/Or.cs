using System.Collections.Generic;
  

namespace SimpleExpressions.Core.Converters.EitherOr
{
    public class Or: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Or" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add(")");
            regularExpressionSofar.Add("|");
            regularExpressionSofar.Add("(");
            return regularExpressionSofar;
        }
    }
}
