using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class Letters : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Letters" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}