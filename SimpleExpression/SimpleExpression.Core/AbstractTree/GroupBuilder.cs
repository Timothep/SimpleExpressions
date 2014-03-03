using System;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree
{
    public class GroupBuilder: BaseBuilder, IBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode newNode = new GroupNode(converter) {Cardinality = new Cardinality()};

            // If it is the first element
            if (currentParent == null)
                return newNode;
            
            if (currentParent is IMotherNode) { /* Do nothing else */ }
            else if (currentParent.Parent is IMotherNode)
                currentParent = currentParent.Parent;
            else
                throw new ArgumentException("The chain being built is invalid");
            
            LinkNodeToParent(currentParent, newNode);

            return newNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Group;
        }
    }
}