﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public interface IConverter
    {
        bool CanParse(string token);
        IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern);
    }
}