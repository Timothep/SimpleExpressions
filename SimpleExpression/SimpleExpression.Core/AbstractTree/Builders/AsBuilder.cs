using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Grouping;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class AsBuilder : BaseBuilder
    {
        public override INode AddNode(INode currentParent, IConverter converter)
        {
            //Assumptions
            // "AS" comes after "TOGETHER"
            // Current pointer should be on the parent of the GROUP
            // Group should be the last of the children

            //Navigate to the group
            if(currentParent == null || currentParent as IMotherNode == null)
                throw new ArgumentException("Something aweful must have happened, poor AS operator... alone like this...");

            //If the current parent is the root
            GroupNode group;
            if (currentParent.Parent == null && currentParent is GroupNode)
                group = currentParent as GroupNode;
            else
            {
                group = (currentParent as IMotherNode).Children.Last() as GroupNode;
                if (group == null)
                    throw new ArgumentException("Something aweful must have happened, poor AS operator... without a group to hangout with...");    
            }

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
