﻿using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
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