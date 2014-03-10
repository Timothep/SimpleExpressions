using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree.Builders.Containers
{
    public class GroupBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            var newNode = new GroupNode(converter);            
            this.LinkNodeToParent(currentParent, newNode);
            return newNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Group;
        }
    }
}