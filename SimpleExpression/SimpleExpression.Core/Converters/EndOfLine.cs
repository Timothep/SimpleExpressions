﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public class EndOfLine : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "EndOfLine" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        private const NodeType Type = NodeType.SimpleNode;
        public override NodeType NodeType
        {
            get { return Type; }
        }

        public override IList<string> Generate(IList<Function> tokens, int currentIndex, IList<string> pattern)
        {
            pattern.Add("$"); //Should be the very last?
            return pattern;
        }
    }
}
