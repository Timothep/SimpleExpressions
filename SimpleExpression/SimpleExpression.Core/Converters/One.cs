using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class One : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "One" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}