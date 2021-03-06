﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class EndOfLine : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "EndOfLine" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
