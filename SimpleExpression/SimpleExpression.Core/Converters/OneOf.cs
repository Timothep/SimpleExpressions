using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class OneOf: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "OneOf" };

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
