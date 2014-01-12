using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Tokens;

namespace SimpleExpressions.Core.Extensions
{
    public static class ListExtension
    {
        public static IToken GetTokenizer(this IList<IToken> tokenizers, string token)
        {
            return tokenizers.FirstOrDefault(tokenizer => tokenizer.CanParse(token));
        }
    }
}
