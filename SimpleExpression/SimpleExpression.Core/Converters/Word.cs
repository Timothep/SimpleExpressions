using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Word: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Word" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
