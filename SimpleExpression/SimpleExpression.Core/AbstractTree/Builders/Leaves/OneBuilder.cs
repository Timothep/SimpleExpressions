using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public class OneBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new OneNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is One;
        }
    }
}