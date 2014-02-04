using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Repeat: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Repeat" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            regularExpressionSofar.Add("(");
            return regularExpressionSofar;
        }
    }
}
