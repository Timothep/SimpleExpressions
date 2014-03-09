using System;
using System.Linq;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree.Builders.Modifyers
{
    public class AsBuilder : BaseBuilder
    {
        private const string CheckString =
            " Please double check your expression, the structure should be Group.XYZ.Together.As()";

        public override INode AddNode(INode currentParent, IConverter converter)
        {
            //If the current parent is neither the root nor a group
            if(!(currentParent is IMotherNode))
                throw new ArgumentException("Trying to insert an 'AS' node, but the current node's type '" + currentParent.GetType() + "' is illegal. " + CheckString);

            GroupNode group;

            //If the current parent is the root
            if (currentParent is RootNode)
            {
                group = (currentParent as IMotherNode).Children.Last() as GroupNode;
                if (group == null)
                    throw new ArgumentException("Trying to insert an 'AS' node, but no Group found at root nor in its children. " + CheckString);
            }
            // The current parent is the group
            else if (currentParent is GroupNode)
                group = currentParent as GroupNode;
            else
                throw new ArgumentException("Trying to insert an 'AS' node, but the current node is neither a group nor contains a group as children. " + CheckString);

            if (converter != null && converter.Function != null && converter.Function.Arguments != null && converter.Function.Arguments.Any())
                group.Name = converter.Function.Arguments[0].ToString();
            
            return currentParent;
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is As;
        }
    }
}
