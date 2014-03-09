using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class NumberInRangeNode : InRangeAbstractNode
    {
        public NumberInRangeNode(IConverter converter) : base(converter) { }
    }
}
