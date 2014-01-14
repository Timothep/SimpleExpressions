using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public class Except : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Except" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
             var currentToken = tokens[currentIndex];

            var lastPatternToken = pattern.Last();

            if (!lastPatternToken.EndsWith("]"))
                throw new Exception("The Except function can only be called after a function defining an ensemble (Alphanumeric(s), Letter(s), Number(s) etc.");

            pattern.Remove(lastPatternToken);
            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, "-[" + currentToken.Arguments[0] + "]"));

            return pattern;
        }
    }
}
