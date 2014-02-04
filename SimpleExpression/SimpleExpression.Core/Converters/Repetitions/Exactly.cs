using System;
using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class Exactly: BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Exactly" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        private const NodeType Type = NodeType.PostfixedQualifier;
        public override NodeType NodeType
        {
            get { return Type; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if(currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            //Close the repeat ")"
            pattern.Add(")");

            string arg0 = currentToken.Arguments[0].ToString();
            pattern.Add("{" + arg0 + "}");

            return pattern;
        }
    }
}
