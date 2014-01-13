using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Converters
{
    public class AtLeast : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "AtLeast" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            var currentToken = tokens[currentIndex];
            
            if (currentToken.Arguments == null)
                throw new ArgumentException("Incorrect number of arguments found");

            var tokenAsInt = Convert.ToInt32(currentToken.Arguments);

            RemoveStar(pattern);
            string additionalPattern = @"{" + tokenAsInt + ",}";
            pattern.Add(additionalPattern);

            return pattern;
        }

        private static void RemoveStar(IList<string> pattern)
        {
            var lastSegment = pattern.Last();
            if (lastSegment != null && lastSegment.Contains("*"))
            {
                var indexOfStar = lastSegment.IndexOf('*');
                var trimmedSegment = lastSegment.Remove(indexOfStar, 1);
                pattern.RemoveAt(pattern.Count - 1);
                pattern.Add(trimmedSegment);
            }
        }
    }
}
