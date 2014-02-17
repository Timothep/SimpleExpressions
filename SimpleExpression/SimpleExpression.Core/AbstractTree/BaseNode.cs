using System.Collections.Generic;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface INode
    {
        BaseNode Parent { get; set; }
        Cardinality Cardinality { get; set; }
    }

    public class BaseNode: INode
    {
        public BaseNode Parent { get; set; }
        public Cardinality Cardinality { get; set; }
    }

    public class Cardinality
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public abstract class BlockNode: BaseNode
    {
        public IList<INode> Children { get; set; }

        protected BlockNode()
        {
            Children = new List<INode>(0);
        }
    }

    public class GroupNode: BlockNode
    {
        public string Name { get; set; }
    }

    public class ClassNode: BlockNode { }

    public class ConcatNode: BlockNode { }

    public class LeafNode: BaseNode
    {
        public string Value { get; set; }
    }
}
