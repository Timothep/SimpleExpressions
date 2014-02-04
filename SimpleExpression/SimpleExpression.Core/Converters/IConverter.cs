using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public interface IConverter
    {
        bool CanParse(string token);
        IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern);
        NodeType NodeType { get; }
    }
}