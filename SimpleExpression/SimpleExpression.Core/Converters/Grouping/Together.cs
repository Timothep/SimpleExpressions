using System.Collections.Generic;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class Together:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Together" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
