using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public class AtMost:BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "AtMost" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern)
        {
            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var lastPatternToken = pattern.Last();

            if (!lastPatternToken.EndsWith(",}"))
                throw new Exception("The AtMost function can only be called after an AtLeast function");

            pattern.Remove(lastPatternToken);
            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, currentToken.Arguments[0].ToString()));

            return pattern;
        }
    }
}
