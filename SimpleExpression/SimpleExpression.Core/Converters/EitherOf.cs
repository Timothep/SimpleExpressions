﻿using System.Collections.Generic;
using SimpleExpressions.Core.Parser;

namespace SimpleExpressions.Core.Converters
{
    public class EitherOf : BaseConverter
    {
        private readonly IList<string> functions = new List<string> { "EitherOf" };
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
            var arg = tokens[currentIndex].Arguments[0].ToString();

            if(!arg.Contains("|"))
                pattern.Add("[" + arg + "]");
            else
                pattern.Add(arg);

            return pattern;
        }
    }
}
