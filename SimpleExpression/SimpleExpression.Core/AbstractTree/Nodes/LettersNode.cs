using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Nodes
{
    public class LettersNode : ExtensibleNode
    {
        public LettersNode(IConverter converter) : base(converter)
        {
            this.Pattern = "[a-zA-Z]";
        }
    }
}
