using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class AlphanumericsNode : ExtensibleNode
    {
        public AlphanumericsNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            var result = "a-zA-Z0-9";

            // if an AND node was attached
            if (this.ExtensionNode != null)
            {
                result = result.Insert(0, "[");
                result += this.ExtensionNode.Generate();
                result += "]";

                if (this.Cardinality.Min == null && this.Cardinality.Min == this.Cardinality.Max)
                    result += "*";
            }

            return string.IsNullOrEmpty(this.Cardinality.ToString()) ? result : string.Format("[{0}]{1}", result, this.Cardinality);
        }
    }
}