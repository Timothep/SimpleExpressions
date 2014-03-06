using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class AlphanumericsNode : ValueNode
    {
        public AlphanumericsNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            const string result = "a-zA-Z0-9";
            return string.IsNullOrEmpty(this.Cardinality.ToString()) ? result : string.Format("[{0}]{1}", result, this.Cardinality);
        }
    }
}