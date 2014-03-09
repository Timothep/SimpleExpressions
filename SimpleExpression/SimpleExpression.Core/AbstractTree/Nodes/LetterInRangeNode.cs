using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class LetterInRangeNode : InRangeAbstractNode
    {
        public LetterInRangeNode(IConverter converter) : base(converter) { }
    }
}
