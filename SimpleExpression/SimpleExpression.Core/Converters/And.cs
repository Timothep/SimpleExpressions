using System;
using System.Collections.Generic;
 
namespace SimpleExpressions.Core.Converters
{
    public class And: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "And" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }
    }
}
