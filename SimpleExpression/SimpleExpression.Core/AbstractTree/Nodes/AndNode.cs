using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class AndNode : ValueNode
    {
        public AndNode(IConverter converter) : base(converter) { }
    }
}