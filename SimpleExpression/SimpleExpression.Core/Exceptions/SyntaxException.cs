using System;

namespace SimpleExpressions.Core.Exceptions
{
    public class SyntaxException: SystemException
    {
        public SyntaxException(string message) : base(message){ }
    }
}
