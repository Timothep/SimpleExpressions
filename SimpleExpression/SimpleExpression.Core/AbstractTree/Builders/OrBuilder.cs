using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.EitherOr;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class OrBuilder: BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            INode orNode = new OrNode(converter);

            // First element of a chain
            if (currentParent == null)
                throw new NotImplementedException("Or cannot be the first element");

            // Insert before its parent
            if (currentParent.Parent != null && currentParent.Parent as IMotherNode != null)
            {
                var grandParent = currentParent.Parent as IMotherNode;
                grandParent.Children.Remove(currentParent);
                (orNode as OrNode).Children.Add(currentParent);
                currentParent = currentParent.Parent;
            }

            this.LinkNodeToParent(currentParent, orNode);
            return orNode;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Or;
        }
    }
}
