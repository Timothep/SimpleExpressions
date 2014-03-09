using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Sets
{
    public class SetBegin : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "SetBegin" };

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
