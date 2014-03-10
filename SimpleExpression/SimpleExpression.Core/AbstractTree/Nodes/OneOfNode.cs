using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OneOfNode : ValueNode
    {
        public OneOfNode(IConverter converter) : base(converter) { }

        public override string Generate()
        {
            return string.Format("({0}){1}", this.Value, this.Cardinality.ToString());
        }
    }
}