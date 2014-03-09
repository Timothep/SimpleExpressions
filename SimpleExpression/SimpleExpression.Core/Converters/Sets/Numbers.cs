using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class Numbers : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Numbers" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}