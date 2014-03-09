using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public class EitherOfBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new EitherOfNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is EitherOf;
        }
    }
}
