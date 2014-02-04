using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public abstract class BaseConverter: IConverter
    {
        public abstract IList<string> Functions { get; }

        public abstract IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern);

        public bool CanParse(string token)
        {
            return this.Functions.Contains(token);
        }

        public abstract NodeType NodeType { get; }
    }
}
