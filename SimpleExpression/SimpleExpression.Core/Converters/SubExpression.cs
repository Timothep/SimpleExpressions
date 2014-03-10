using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class SubExpression : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "SubExpression" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
