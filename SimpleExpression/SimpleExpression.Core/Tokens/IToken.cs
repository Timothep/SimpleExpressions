using System.Collections.Generic;

namespace SimpleExpressions.Core.Tokens
{
    public interface IToken
    {
        bool CanParse(string token);
        IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern);
    }
}