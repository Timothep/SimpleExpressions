using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class EitherOf : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "EitherOf" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
