using System;
using System.Collections.Generic;
  

namespace SimpleExpressions.Core.Converters
{
    public class OneOf: BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "OneOf" };

        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            if (this.Function.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            if (this.Function.Arguments.Length != 1 && this.Function.Arguments[0].ToString().Length != 1)
                throw new ArgumentException("Use the singular version 'Character' if you want to check for one character only");

            var arg0 = this.Function.Arguments[0].ToString();
            if (arg0.Contains("."))
                arg0 = arg0.Insert(arg0.IndexOf(".", StringComparison.Ordinal), @"\");

            regularExpressionSofar.Add("[" + arg0 + "]");
            return regularExpressionSofar;
        }
    }
}
