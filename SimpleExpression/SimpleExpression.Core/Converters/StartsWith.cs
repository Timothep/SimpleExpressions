using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class StartsWith: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "StartsWith" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
