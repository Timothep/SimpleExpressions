using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
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
}