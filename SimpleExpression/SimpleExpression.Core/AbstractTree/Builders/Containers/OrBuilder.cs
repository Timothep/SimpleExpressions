using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.EitherOr;

namespace SimpleExpressions.Core.AbstractTree.Builders.Containers
{
    public class OrBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode newNode = new OrNode(converter);
            this.LinkNodeToParent(currentParent, newNode);
            return newNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Or;
        }
    }
}
