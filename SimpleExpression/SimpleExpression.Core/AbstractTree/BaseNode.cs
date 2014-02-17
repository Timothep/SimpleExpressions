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

    public abstract class GroupNode : BlockNode
    {
        public string Name { get; set; }
    }

    public class ClassNode : BlockNode
    {
    }

    public class ConcatNode: BlockNode
    {
    }

    public class TextNode: BaseNode
    {
        public string Value { get; set; }
    }
}
