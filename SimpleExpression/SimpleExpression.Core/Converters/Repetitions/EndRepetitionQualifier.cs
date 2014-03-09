using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class EndRepetitionQualifier : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "EndRepetitionQualifier" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}