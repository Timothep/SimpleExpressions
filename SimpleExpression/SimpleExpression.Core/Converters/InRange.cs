using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class InRange : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "InRange" };

        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];

            if (currentToken.Arguments == null)
                throw new ArgumentException("Missing argument");

            var findLastGroupTokenIndex = FindLastGroupTokenIndex(pattern);

            pattern.RemoveAt(findLastGroupTokenIndex);
            pattern.Insert(findLastGroupTokenIndex, RangeBuilder.CreateRange(currentToken.Arguments[0].ToString()));

            return pattern;
        }

        private static int FindLastGroupTokenIndex(IList<string> pattern)
        {
            var i = -1;
            for (var j = 0; j < pattern.Count; j++)
            {
                if (pattern[j].Contains("]"))
                    i = j;
            }
            return i;
        }
    }
}