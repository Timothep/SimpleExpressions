using System;
using System.Collections.Generic;

namespace SimpleExpressions.Core.Converters
{
    public class One : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "One" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            if (this.Function.Arguments.Length != 1)
                throw new ArgumentException("Incorrect number of arguments found");

            var arg0 = this.Function.Arguments[0].ToString();
            if (arg0.Contains("."))
                arg0 = arg0.Insert(arg0.IndexOf(".", StringComparison.Ordinal), @"\");

            regularExpressionSofar.Add(arg0);
            return regularExpressionSofar;
        }
    }
}