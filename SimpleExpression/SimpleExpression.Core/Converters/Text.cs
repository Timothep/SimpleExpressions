﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class Text : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Text" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
