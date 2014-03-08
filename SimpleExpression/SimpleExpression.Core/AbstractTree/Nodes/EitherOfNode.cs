using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class EitherOfNode : ValueNode
    {
        public EitherOfNode(IConverter converter) : base(converter) { }
    }
}