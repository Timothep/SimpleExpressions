using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    /// <summary>
    /// ExceptWord("blah") -> ^(.(?!blah))*$
    /// </summary>
    public class ExceptWord : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "ExceptWord" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}