using System;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public class TextBuilder: BaseBuilder, IBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode textNode = new TextNode { Cardinality = new Cardinality() };

            // If the currentParent is not an IMotherNode
            if (!(currentParent is IMotherNode))
            {
                // If the currentParent has no parent
                if (currentParent == null)
                {
                    var concat = new ConcatNode { Cardinality = new Cardinality() };
                    currentParent = concat;
                }
                // If the parent cannot host a child, dock it to its parent
                else if (currentParent.Parent is IMotherNode)
                {
                    currentParent = currentParent.Parent;
                }
                else
                    throw new NotImplementedException("No correct node found for insertion");
            }

            LinkNodeToParent(currentParent, textNode);
            return textNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Text;
        }
    }
}