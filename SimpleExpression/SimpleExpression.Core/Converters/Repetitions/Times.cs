﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Times : BaseConverter
    {
        private readonly IList<string> functions = new List<string> {"Times"};

        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            return pattern;
        }
    }
}