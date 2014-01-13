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

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if (currentToken.Arguments == null)
                throw new ArgumentException("Incorrect number of arguments found");

            var tokenAsInt = Convert.ToInt32(currentToken.Arguments);

            var lastPatternToken = pattern.Last();

            if (!lastPatternToken.EndsWith(",}"))
                throw new Exception("The AtMost function can only be called after an AtLeast function");

            pattern.Remove(lastPatternToken);
            
            string tokenToInsert = lastPatternToken.Insert(lastPatternToken.Length - 1, tokenAsInt.ToString());
            pattern.Add(tokenToInsert);

            return pattern;
        }
    }
}
