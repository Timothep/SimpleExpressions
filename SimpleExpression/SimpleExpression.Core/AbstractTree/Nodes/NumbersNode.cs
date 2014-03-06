using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class NumbersNode : ValueNode
    {
        public NumbersNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            const string result = "0-9";
            return string.IsNullOrEmpty(this.Cardinality.ToString()) ? result : string.Format("[{0}]{1}", result, this.Cardinality);
        }
    }
}