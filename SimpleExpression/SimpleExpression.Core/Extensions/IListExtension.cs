using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Extensions
{
    public static class ListExtension
    {
        public static IConverter GetConverters(this IList<IConverter> tokenizers, string token)
        {
            return tokenizers.FirstOrDefault(tokenizer => tokenizer.CanParse(token));
        }
    }
}
