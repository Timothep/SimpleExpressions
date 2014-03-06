using SimpleExpressions.Core.AbstractTree.Nodes;
using SimpleExpressions.Core.Converters;
using SimpleExpressions.Core.Converters.Sets;

namespace SimpleExpressions.Core.AbstractTree.Builders
{
    public class LettersBuilder: LeafBuilder
    {
        protected override INode GetNode(IConverter converter)
        {
            return new LettersNode(converter);
        }

        public override bool CanHandle(IConverter converter)
        {
            return converter is Letters;
        }
    }
}
