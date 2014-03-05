using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
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
}