using System.Collections.Generic;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface INode
    {
        INode Parent { get; set; }
        Cardinality Cardinality { get; set; }
    }

    public interface IMotherNode
    {
        void AddChild(INode node);
        IList<INode> Children { get; set; }
    }

    public abstract class BaseNode: INode
    {
        public INode Parent { get; set; }
        public Cardinality Cardinality { get; set; }
    }

    public class Cardinality
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public Cardinality(CardinalityEnum card = CardinalityEnum.ExactlyOne)
        {
            switch (card)
            {
                case CardinalityEnum.ZeroOrMore:
                    this.Min = 0;
                    this.Max = int.MaxValue;
                    break;
                case CardinalityEnum.ZeroToOne:
                    this.Min = 0;
                    this.Max = 1;
                    break;
                case CardinalityEnum.ExactlyOne:
                    this.Min = 1;
                    this.Max = 1;
                    break;
                case CardinalityEnum.OneOrMore:
                    this.Min = 1;
                    this.Max = int.MaxValue;
                    break;
            }
        }
    }

    public enum CardinalityEnum
    {
        ZeroOrMore = 0,
        ZeroToOne,
        ExactlyOne,
        OneOrMore,
    }

    /// <summary>
    /// Represents a grouping node, e.g. a node that can have children
    /// </summary>
    public abstract class BlockNode: BaseNode, IMotherNode
    {
        public IList<INode> Children { get; set; }

        protected BlockNode()
        {
            Children = new List<INode>(0);
        }

        public void AddChild(INode node)
        {
            this.Children.Add(node);
        }
    }

    /// <summary>
    /// Represents a group, e.g. a block that might have a name
    /// </summary>
    public class GroupNode : BlockNode
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents a class, e.g. a block which elements form a single Regular Expression entity
    /// Ex: "Letters AND Numbers", per opposition to "Letters THEN Numbers"
    /// </summary>
    public class ClassNode : BlockNode { }

    /// <summary>
    /// Represents a concatenation of elements
    /// </summary>
    public class ConcatNode: BlockNode { }

    /// <summary>
    /// A simple node having a text value
    /// </summary>
    public class TextNode: BaseNode
    {
        public string Value { get; set; }
    }
}
