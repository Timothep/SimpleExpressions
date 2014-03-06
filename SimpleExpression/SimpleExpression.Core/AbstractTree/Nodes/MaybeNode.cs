using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class MaybeNode : ValueNode
    {
        public MaybeNode(IConverter converter): base(converter) { }

        public override string Generate()
        {
            return string.Format("({0})?", this.Value);
        }
    }
}