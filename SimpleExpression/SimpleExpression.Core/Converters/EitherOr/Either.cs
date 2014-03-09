using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.EitherOr
{
    public class Either: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Either" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
