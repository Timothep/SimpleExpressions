using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public class Max:BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Max" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var lastPatternToken = pattern.Last();

            pattern.Remove(lastPatternToken);
            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, currentToken.Arguments[0].ToString()));

            return pattern;
        }
    }
}
