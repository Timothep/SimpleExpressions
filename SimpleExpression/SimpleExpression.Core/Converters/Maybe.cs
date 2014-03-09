using System.Collections.Generic;
 
namespace SimpleExpressions.Core.Converters
{
    public class Maybe: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Maybe" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
