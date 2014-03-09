using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class FollowedBy: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "FollowedBy" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
