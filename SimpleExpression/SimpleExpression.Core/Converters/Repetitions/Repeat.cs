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
    }
}
