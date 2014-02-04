using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public interface IConverter
    {
        bool CanParse(string functionName);
        IList<string> Generate(IList<string> regularExpressionSofar);
        Function Function { get; set; }
    }
}