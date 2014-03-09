using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public class OneOfBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new OneOfNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is OneOf;
        }
    }
}