using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Exactly: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Exactly" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
