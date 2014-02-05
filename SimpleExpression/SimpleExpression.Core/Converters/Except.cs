using System.Collections.Generic;
using System.Linq;
  

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

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;
            
            regularExpressionSofar.Add("-[" + currentToken.Arguments[0] + "]");
            return regularExpressionSofar;
        }
    }

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

        //^(.(?!arg))*$
        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;
            var lastPatternToken = regularExpressionSofar.Last();
            var arg = currentToken.Arguments[0];
            regularExpressionSofar.Remove(lastPatternToken);
            regularExpressionSofar.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, "[^" + arg + "]"));
            return regularExpressionSofar;
        }
    }
}
