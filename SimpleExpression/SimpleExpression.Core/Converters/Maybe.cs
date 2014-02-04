using System;
using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public class Maybe: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Maybe" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        private const NodeType Type = NodeType.Operator;
        public override NodeType NodeType
        {
            get { return Type; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if(currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            string arg0 = currentToken.Arguments[0].ToString();
            pattern.Add("(" + arg0 + ")?");

            return pattern;
        }
    }
}
