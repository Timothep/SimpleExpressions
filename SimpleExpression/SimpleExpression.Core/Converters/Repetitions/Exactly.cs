using System;
using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Exactly: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Exactly" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if(currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            //Close the repeat ")"
            regularExpressionSofar.Add(")");

            string arg0 = currentToken.Arguments[0].ToString();
            regularExpressionSofar.Add("{" + arg0 + "}");

            return regularExpressionSofar;
        }
    }
}
