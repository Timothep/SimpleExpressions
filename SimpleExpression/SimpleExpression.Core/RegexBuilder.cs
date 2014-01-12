using System;
using System.Collections.Generic;
using SimpleExpressions.Core.Extensions;
using SimpleExpressions.Core.Tokens;

namespace SimpleExpressions.Core
{
    public static class RegexBuilder
    {
        public static IList<string> Generate(IList<Function> chain)
        {
            IList<string> pattern = new List<string>(0);
            IList<IToken> tokenizers = new List<IToken>
                {
                    new SimpleSet(),
                    new One(),
                    new AtLeast(),
                    new AtMost(),
                };

            foreach (var function in chain)
            {
                var tokenizer = tokenizers.GetTokenizer(function.Name);
                pattern = tokenizer.Generate(chain, function, pattern);
            }

            return pattern;
        }
    }
}