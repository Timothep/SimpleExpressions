using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Grouping
{
    public class Group:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Group" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
