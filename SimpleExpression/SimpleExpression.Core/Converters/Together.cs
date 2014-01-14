﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Together:BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "Together" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add(")");
            return pattern;
        }
    }
}
