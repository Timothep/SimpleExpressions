using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core
{
    public class ExpressionBuilder
    {
        public IList<string> GenerateRegularExpression(IList<IConverter> completeConverterChain)
        {
            IList<string> pattern = new List<string>(0);
            return completeConverterChain.Aggregate(pattern, (current, converter) => converter.Generate(current));
        }
    }
}