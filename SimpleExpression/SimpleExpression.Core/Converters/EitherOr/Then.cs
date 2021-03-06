﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.EitherOr
{
    public class Then: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "Then" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
