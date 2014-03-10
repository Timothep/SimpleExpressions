using System;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public class SubExpressionBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new SubExpressionNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is SubExpression;
        }
    }
}
