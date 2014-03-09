using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtMost:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "AtMost" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
