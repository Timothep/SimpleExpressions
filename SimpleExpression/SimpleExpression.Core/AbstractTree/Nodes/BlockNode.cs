using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    /// <summary>
    ///     Represents a grouping node, e.g. a node that can have children
    /// </summary>
    public abstract class BlockNode : BaseNode, IMotherNode
    {
        protected BlockNode(IConverter converter): base(converter)
        {
            this.Children = new List<INode>(0);
        }

        public IList<INode> Children { get; set; }

        public void AddChild(INode node)
        {
            this.Children.Add(node);
        }

        protected string AggregateChildren()
        {
            return this.Children.Aggregate("", (current, child) => current + child.Generate());
        }
    }
}