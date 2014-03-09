using System;
using System.Collections.Generic;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public abstract class LeafBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode textNode = this.GetNode(converter);

            // First element of a chain must be concatenated
            if (currentParent == null)
            {
                var concat = new ConcatNode(converter);
                currentParent = concat;
            }
            //If the parent is a CONCAT or OR node, add this node to the list
            else if (currentParent is ConcatNode || currentParent is OrNode) { /* Do nothing special */ }
            //else if (currentParent is IMotherNode)
            else if (currentParent is GroupNode)
            {
                // If the parent is a group node, but not a concat, insert a concat in between
                var concat = new ConcatNode(converter);
                
                // Relink all the children of the group
                var listClone = new List<INode>((currentParent as IMotherNode).Children);
                foreach (var child in listClone)
                {
                    child.Parent = concat;
                    (currentParent as IMotherNode).Children.Remove(child);
                    concat.AddChild(child);
                }

                (currentParent as IMotherNode).AddChild(concat);
                concat.Parent = currentParent;
                currentParent = concat;
            }
            else
            {
                //Try linking it to it's parent's parent
                if(!(currentParent.Parent is IMotherNode))
                    throw new ArgumentException("The chain being built is invalid");

                currentParent = currentParent.Parent;
            }

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