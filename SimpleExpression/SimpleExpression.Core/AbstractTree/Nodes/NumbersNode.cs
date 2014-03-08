using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class NumbersNode : ValueNode
    {
        private const string Pattern = "[0-9]";

        public NumbersNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var result = Pattern;

            if (this.Cardinality.Min == null && this.Cardinality.Min == this.Cardinality.Max)
                result += "*";

            return string.IsNullOrEmpty(this.Cardinality.ToString()) ? result : string.Format("{0}{1}", result, this.Cardinality);
        }
    }
}