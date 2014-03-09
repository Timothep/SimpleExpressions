using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtLeast : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "AtLeast" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
