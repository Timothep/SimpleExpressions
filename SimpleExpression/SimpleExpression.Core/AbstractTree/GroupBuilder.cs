using System;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree
{
    public class GroupBuilder: BaseBuilder, IBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode newNode = new GroupNode {Cardinality = new Cardinality()};

            // If it is the first element
            if (currentParent == null)
                return newNode;

            if (currentParent as IMotherNode != null)
                LinkNodeToParent(currentParent, newNode);

            throw new NotImplementedException("No correct node found for insertion");
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Group;
        }
    }

    public class TransparentBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Together;
        }
    }

    public abstract class BaseBuilder: IBuilder
    {
        public void LinkNodeToParent(INode parent, INode newNode)
        {
            newNode.Parent = parent;
            var motherNode = parent as IMotherNode;
            if (motherNode != null) 
                motherNode.AddChild(newNode);
        }

        public abstract INode AddNode(INode currentParent, IConverter converter);

        public abstract bool CanHandle(IConverter converter);
    }
}