using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class MaybeBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new MaybeNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Maybe;
        }
    }
}