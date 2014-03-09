using System;
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

            // If it is the first element
            if (currentParent is RootNode) { /* Do nothing */ }
            else if (currentParent is IMotherNode) { /* Do nothing else */ }
            else if (currentParent.Parent is IMotherNode)
                currentParent = currentParent.Parent;
            else
                throw new ArgumentException("The chain being built is invalid");
            
            this.LinkNodeToParent(currentParent, newNode);

            return newNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Group;
        }
    }
}