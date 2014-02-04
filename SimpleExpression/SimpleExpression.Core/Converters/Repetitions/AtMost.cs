using System;
using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class AtMost:BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "AtMost" };
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

            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            //If it is the first after the repeat, close the ")"
            if (IsPartOfARepeatLoop(tokens, currentIndex) && tokens[currentIndex - 1].Name != "AtLeast")
                pattern.Add(")");

            var lastPatternToken = pattern.Last();

            pattern.Remove(lastPatternToken);
            pattern.Add(lastPatternToken.Insert(lastPatternToken.Length - 1, currentToken.Arguments[0].ToString()));

            return pattern;
        }

        private static bool IsPartOfARepeatLoop(IList<Function> tokens, int currentIndex)
        {
            //If there is a "Times" token on the right (maybe with a AtMost() in between)
            if (tokens.Count > (currentIndex + 1) && tokens[currentIndex + 1].Name == "Times")
                return true;

            return false;
        }
    }
}
