using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class ExceptNode : ValueNode
    {
        public ExceptNode(IConverter converter) : base(converter) { }
    }
}