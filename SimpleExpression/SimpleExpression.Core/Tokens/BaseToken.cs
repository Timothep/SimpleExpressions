using System.Collections.Generic;

namespace SimpleExpressions.Core.Tokens
{
    public abstract class BaseToken: IToken
    {
        public abstract IList<string> Functions { get; }

        public bool CanParse(string token)
        {
            return this.Functions.Contains(token);
        }

        public abstract IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern);
    }
}
