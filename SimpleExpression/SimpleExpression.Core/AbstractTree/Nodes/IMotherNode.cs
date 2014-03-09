using System.Collections.Generic;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public interface IMotherNode
    {
        IList<INode> Children { get; set; }
    }
}