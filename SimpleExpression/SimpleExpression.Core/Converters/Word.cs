using System;
using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class Word: BaseConverter
    {
         private readonly IList<string> supportedFunctionNames = new List<string> { "Word" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            string arg0 = currentToken.Arguments[0].ToString();
            var escapedWordBoundary = @"\b";
            regularExpressionSofar.Add(escapedWordBoundary + arg0 + escapedWordBoundary);

            return regularExpressionSofar;
        }
    }
}
