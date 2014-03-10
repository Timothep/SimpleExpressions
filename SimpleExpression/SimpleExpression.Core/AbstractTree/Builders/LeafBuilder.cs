using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public abstract class LeafBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            var textNode = this.GetNode(converter);
            this.LinkNodeToParent(currentParent, textNode);
            return textNode;
        }

        protected abstract INode GetNode(IConverter converter);

        public override bool CanHandle(IConverter converter)
        {
            return converter is Text;
        }
    }
}