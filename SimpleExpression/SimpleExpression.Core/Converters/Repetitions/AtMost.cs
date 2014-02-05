using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtMost:BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "AtMost" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            regularExpressionSofar.Add(currentToken.Arguments[0].ToString());

            return regularExpressionSofar;
        }
    }
}
