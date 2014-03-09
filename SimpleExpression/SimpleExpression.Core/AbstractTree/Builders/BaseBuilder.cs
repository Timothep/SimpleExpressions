using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public abstract class BaseBuilder: IBuilder
    {
        public void LinkNodeToParent(INode parent, INode newNode)
        {
            newNode.Parent = parent;
            var motherNode = parent as IMotherNode;
            if (motherNode != null) 
                motherNode.Children.Add(newNode);
        }

        public abstract INode AddNode(INode currentParent, IConverter converter);

        public abstract bool CanHandle(IConverter converter);
    }
}