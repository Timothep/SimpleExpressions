using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class OneNode : ValueNode
    {
        public OneNode(IConverter converter) : base(converter) { }
    }
}