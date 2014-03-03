using System.Collections.Generic;
using System.Linq;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree
{
    public interface INode
    {
        INode Parent { get; set; }
        Cardinality Cardinality { get; set; }
        string Generate();
        IConverter Converter { get; set; }
    }

    public interface IMotherNode
    {
        IList<INode> Children { get; set; }
        void AddChild(INode node);
    }

    public abstract class BaseNode : INode
    {
        public INode Parent { get; set; }
        public Cardinality Cardinality { get; set; }
        public IConverter Converter { get; set; }
        public abstract string Generate();

        protected BaseNode(IConverter converter)
        {
            this.Converter = converter;
        }
    }

    public class Cardinality
    {
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

        public int Min { get; set; }
        public int Max { get; set; }
    }

    public enum CardinalityEnum
    {
        ZeroOrMore = 0,
        ZeroToOne,
        ExactlyOne,
        OneOrMore,
    }

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

    /// <summary>
    ///     Represents a group, e.g. a block that might have a name
    /// </summary>
    public class GroupNode : BlockNode
    {
        public string Name { get; set; }

        public GroupNode(IConverter converter, string name = "")
            : base(converter)
        {
            this.Name = name;
        }

        public override string Generate()
        {
            var alias = "";          //todo
            var childrenAggregate = this.AggregateChildren();
            var cardinality = "";    //todo

            return string.Format("({0}{1}{2})", alias, childrenAggregate, cardinality);
        }
    }

    /// <summary>
    ///     Represents a class, e.g. a block which elements form a single Regular Expression entity
    ///     Ex: "Letters AND Numbers", per opposition to "Letters THEN Numbers"
    /// </summary>
    public class ClassNode : BlockNode
    {
        public ClassNode(IConverter converter)
            : base(converter) { }

        public override string Generate()
        {
            var childrenAggregate = this.AggregateChildren();
            var cardinality = "";    //todo

            return string.Format("({0}{1})", childrenAggregate, cardinality);
        }
    }

    /// <summary>
    ///     Represents a concatenation of elements
    /// </summary>
    public class ConcatNode : BlockNode
    {
        public ConcatNode(IConverter converter)
            : base(converter) { }

        public override string Generate()
        {
            var childrenAggregate = this.AggregateChildren();
            var cardinality = "";    //todo

            return string.Format("{0}{1}", childrenAggregate, cardinality);
        }
    }

    /// <summary>
    ///     A simple node having a text value
    /// </summary>
    public class TextNode : BaseNode
    {
        public TextNode(IConverter converter)
            : base(converter)
        {
            if (converter.Function != null && converter.Function.Arguments != null)
                this.Value = converter.Function.Arguments[0].ToString();
            else
                this.Value = "";
        }

        public string Value { get; set; }

        public override string Generate()
        {
            return this.Value;
        }
    }
}