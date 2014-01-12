﻿using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class One: BaseConverter
    {
        private readonly IList<string> functions = new List<string>{ "One" };
        public override IList<string> Functions
        {
            get { return this.functions; }
        }

        public override IList<string> Generate(IList<Function> tokens, Function currentToken, IList<string> pattern)
        {
            if(currentToken.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            string arg0 = currentToken.Arguments[0].ToString();
            if (currentToken.Arguments[0].ToString() == ".")
                arg0 = @"\" + arg0;
            pattern.Add(arg0);

            return pattern;
        }
    }
}