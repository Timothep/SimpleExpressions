using System.Collections.Generic;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.Rewriters
{
    public interface IRewriter
    {
        IList<IConverter> CompleteConverterChain(IList<IConverter> converterChain);
    }
}