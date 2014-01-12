﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressions.Core.Tokens
{
    public class AtLeast : BaseToken
    {
        private readonly IList<string> functions = new List<string> { "AtLeast" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern)
        {
            if (currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            RemoveStar(pattern);
            pattern.Add(@"{" + currentToken.Arguments[0] + ",}");

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
