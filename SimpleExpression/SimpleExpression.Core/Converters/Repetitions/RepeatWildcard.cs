using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    class RepeatWildcard : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "RepeatWildcard" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
