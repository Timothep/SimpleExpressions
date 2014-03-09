using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class As : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "As" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
