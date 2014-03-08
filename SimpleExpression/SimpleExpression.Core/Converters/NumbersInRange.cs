using System;
using System.Collections.Generic;
using SimpleExpressions.Core.AbstractTree.Nodes;


namespace SimpleExpressions.Core.Converters
{
    public class NumbersInRange : BaseConverter
    {
        private readonly IList<string> supportedFunctionNames = new List<string> { "NumbersInRange" };
        public override IList<string> SupportedFunctionNames
        {
            get { return this.supportedFunctionNames; }
        }

        public override IList<string> Generate(IList<string> regularExpressionSofar)
        {
            var currentToken = this.Function;

            if (currentToken.Arguments == null)
                throw new ArgumentException("Missing argument");

            regularExpressionSofar.Add(InRangeStaticHelper.CreateRange(currentToken.Arguments[0].ToString()));

            return regularExpressionSofar;
        }
    }
}