using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Exceptions;
using SimpleExpressions.Core.SpecializedSimpleExpression;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class SubExpressionNode: BaseNode
    {
        public SubExpressionNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            if(this.Converter == null ||
                this.Converter.Function == null ||
                this.Converter.Function.Arguments == null ||
                !this.Converter.Function.Arguments.Any())
                throw new SyntaxException("An error occured while parsing the SimpleExpression passed as a SubExpression.");

            var subExpression = this.Converter.Function.Arguments[0] as SimpleExpression;
            if(subExpression == null)
                throw new SyntaxException("The SimpleExpression passed as a SubExpression is not valid.");

            return subExpression.Expression;
        }
    }
}
