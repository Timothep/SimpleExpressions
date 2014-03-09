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
    }
}
