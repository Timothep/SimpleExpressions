﻿using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters.Repetitions
{
    public class RepetitionQualifier: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "RepetitionQualifier" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
