using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class AlphanumericsNode : ExtensibleNode
    {
        public AlphanumericsNode(IConverter converter) : base(converter)
        {
            this.Pattern = "a-zA-Z0-9";
        }
    }
}