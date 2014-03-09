using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;

namespace SimpleExpressions.Core.AbstractTree.Builders.Leaves
{
    public class TextBuilder : LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new TextNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Text;
        }
    }
}