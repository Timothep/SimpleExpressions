using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class One: BaseConverter
    {
        private readonly IList<string> functions = new List<string>{ "One" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if(currentToken.Arguments == null)
                throw new ArgumentException("Missing argument for function");

            string tokenAsString = currentToken.Arguments.ToString();

            if (tokenAsString.ToString() == ".")
                tokenAsString = @"\" + tokenAsString;

            pattern.Add(tokenAsString);

            return pattern;
        }
    }
}
