using System;
using System.Collections.Generic;
 

namespace SimpleExpressions.Core.Converters
{
    public class Text : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Text" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var arg0 = currentToken.Arguments[0].ToString();
            regularExpressionSofar.Add(arg0);

            return regularExpressionSofar;
        }
    }
}
