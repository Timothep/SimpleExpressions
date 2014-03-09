using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    //Cases:
    //Except("a") <- [^a]
    //ExceptRange("a-d") <- [^blah]
    //ExceptLetters("blah") <- except all those letters [^blah]
    public class Except : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Except" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
